
using System;
using System.Reflection;
using UnityEngine;

namespace Framework
{
    public abstract class PageBase<T> : MonoBehaviour where T : PageBase<T>
    {
        public GameObject UI { get; set; }

        public void Destroy()
        {
            Destroy(this);
            Destroy(UI);
        }

        public static string path
        {
            get
            {
                foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
                    if (type.IsSubclassOf(typeof(PageBase<T>)))
                    {
                        FieldInfo pathField = type.GetField("Path");
                        if (pathField != null)
                            return (string)pathField.GetValue(null);
                    }
                return null;
            }
        }

        /// <summary>
        /// 异步加载UI
        /// </summary>
        /// <param name="Ansy"></param>
        public static void CreateAnsy(Action<T> Ansy)
        {
            GameObject canvas = GameObject.FindWithTag("Canvas");
            if (canvas == null)
            {
                Debug.LogError("没有找到Canvas!");
                return;
            }
            AssetsManager<GameObject>.Init.LoadAssetAsync(path, (Object) =>
            {
                if (Object != null)
                {
                    T self = Instantiate(Object, canvas.transform).AddComponent<T>();
                    self.UI = self.gameObject;
                    Ansy?.Invoke(self);
                }
                else
                {
                    Debug.LogError("错误的UI Kye！UI不存在！: " + path);
                    return;
                }
            });
        }

        /// <summary>
        /// 异步加载UI
        /// </summary>
        /// <param name="Ansy"></param>
        public static void CreateAnsy(GameObject parent, Action<T> Ansy)
        {
            AssetsManager<GameObject>.Init.LoadAssetAsync(path, (Object) =>
            {
                if (Object != null)
                {

                    T self = Instantiate(Object, parent.transform).AddComponent<T>();
                    self.UI = self.gameObject;
                    Ansy?.Invoke(self);
                }
                else
                {
                    Debug.LogError("错误的UI Kye！UI不存在！: " + path);
                    return;
                }
            });
        }

        public static T CreateSubobject(GameObject parent)
        {
            if (parent == null)
            {
                Debug.LogError("要添加的父对象为空");
                throw null;
            }
            var self = parent.AddComponent<T>();
            self.UI = parent;
            return self;
        }
    }
}