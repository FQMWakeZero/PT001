using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Framework
{
    /// <summary>
    /// Addressable 资源管理器
    /// </summary>
    public class AssetsManager<T> where T : UnityEngine.Object
    {
        private static AssetsManager<T> init;
        public static AssetsManager<T> Init => init ??= new AssetsManager<T>();

        /// <summary>
        /// 同步加载资源
        /// </summary>
        /// <param name="address">资源地址</param>
        /// <returns>加载的资源对象</returns>
        public T LoadAsset(string address)
        {
            // 启动协程并等待其完成
            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(address);
            handle.WaitForCompletion();

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                return handle.Result;
            }
            else
            {
                Debug.LogError($"未能加载资源 {address}");
                return null;
            }
        }

        

        /// <summary>
        /// 异步加载资源
        /// </summary>
        /// <param name="address">资源地址</param>
        /// <param name="onLoaded">资源加载完成的回调</param>
        public void LoadAssetAsync(string address, Action<T> onLoaded)
        {
            Addressables.LoadAssetAsync<T>(address).Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    onLoaded?.Invoke(handle.Result);
                }
                else
                {
                    Debug.LogError($"未能加载资源 {address}");
                    onLoaded?.Invoke(null);
                }
            };
        }

        /// <summary>
        /// 同步加载场景
        /// </summary>
        /// <param name="address">场景地址</param>
        /// <param name="loadMode">加载模式</param>
        /// <returns>加载的场景</returns>
        public SceneInstance LoadScene(string address, LoadSceneMode loadMode = LoadSceneMode.Single)
        {
            try
            {
                var handle = Addressables.LoadSceneAsync(address, loadMode, true);
                handle.WaitForCompletion();
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    return handle.Result;
                }
                else
                {
                    Debug.LogError($"未能加载资源 {address}");
                    return default;
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"加载场景发生错误 {address}: {e}");
                return default;
            }
        }

        /// <summary>
        /// 异步加载场景
        /// </summary>
        /// <param name="address">场景地址</param>
        /// <param name="loadMode">加载模式</param>
        /// <param name="onLoaded">场景加载完成的回调</param>
        public void LoadSceneAsync(string address, LoadSceneMode loadMode = LoadSceneMode.Single, Action<SceneInstance> onLoaded = null)
        {
            Addressables.LoadSceneAsync(address, loadMode, true).Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    onLoaded?.Invoke(handle.Result);
                }
                else
                {
                    Debug.LogError($"未能加载资源 {address}");
                    onLoaded?.Invoke(default);
                }
            };
        }

        public IEnumerator LoadPrefab(string prefabName, System.Action<GameObject> callback)
        {
            // 检查资源是否已下载
            AsyncOperationHandle<IList<IResourceLocation>> locationsHandle = Addressables.LoadResourceLocationsAsync(prefabName);
            yield return locationsHandle;

            if (locationsHandle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError($"未能加载资源 {prefabName}");
                callback(null);
                yield break;
            }

            IList<IResourceLocation> locations = locationsHandle.Result;
            if (locations == null || locations.Count == 0)
            {
                Debug.LogError($"资源不存在 {prefabName}");
                callback(null);
                yield break;
            }

            IResourceLocation location = locations[0];
            AsyncOperationHandle<long> sizeHandle = Addressables.GetDownloadSizeAsync(location);
            yield return sizeHandle;

            if (sizeHandle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError($"未知资源大小 {prefabName}");
                callback(null);
                yield break;
            }

            long downloadSize = sizeHandle.Result;
            if (downloadSize > 0)
            {
                // 资源未缓存，下载资源
                AsyncOperationHandle downloadHandle = Addressables.DownloadDependenciesAsync(prefabName);
                yield return downloadHandle;

                if (downloadHandle.Status != AsyncOperationStatus.Succeeded)
                {
                    Debug.LogError($"依赖包不存在 {prefabName}");
                    callback(null);
                    yield break;
                }
            }

            // 资源已缓存或下载完成，加载资源
            AsyncOperationHandle<GameObject> loadHandle = Addressables.LoadAssetAsync<GameObject>(prefabName);
            yield return loadHandle;

            if (loadHandle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError($"资源加载失败 {prefabName}");
                callback(null);
            }
            else
            {
                GameObject prefab = loadHandle.Result;
                callback(prefab);
            }
        }
    }
}
