using System;
using UnityEngine;

namespace Framework
{
    public class PageModel<T> : IDisposable where T : PageBase<T>, new()
    {

        /// <summary>
        /// UI原始对象
        /// </summary>
        public T self { get; set; }

        /// <summary>
        /// 设置UI对象为某对象的子对象
        /// </summary>
        /// <param name="parent">父对象</param>
        public void SetParent(GameObject parent)
        {
            if (self != null) self.transform.SetParent(parent.transform);
        }


        /// <summary>
        /// 显示UI
        /// </summary>
        /// <returns>返回显示UI的引用对象</returns>
        public virtual void ShowUIAnsy(Action<T> Ansy = null)
        {
            if (self == null)
            {
                PageBase<T>.CreateAnsy((self) => 
                { 
                    this.self = self; 
                    Ansy?.Invoke(self); 
                    Awake(); 
                    GameInit.Init.UpdateAction += Update; 
                });
            }
            else
            {
                Start();
                self.gameObject.SetActive(true);
            }


        }

        /// <summary>
        /// 显示UI
        /// </summary>
        /// <returns>返回显示UI的引用对象</returns>
        public virtual void ShowUIAnsy(GameObject parent, Action<T> Ansy = null)
        {
            if (self == null)
            {
                PageBase<T>.CreateAnsy(parent ,(self) =>
                { 
                    this.self = self; 
                    Ansy?.Invoke(self); 
                    Awake(); 
                    GameInit.Init.UpdateAction += Update; 
                });
            }
            else
            {
                Start();
                self.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// 隐藏UI，并返回UI引用对象
        /// </summary>
        /// <returns></returns>
        public virtual T HideUI()
        {
            if (self != null)
                self.gameObject.SetActive(false);
            return self;
        }

        /// <summary>
        /// 在UI被创建时执行
        /// </summary>
        public virtual void Awake()
        {

        }

        /// <summary>
        /// 在UI被显示时执行
        /// </summary>
        public virtual void Start()
        {

        }

        /// <summary>
        /// 每帧调用一次,注意如果此处代码复杂，可能会大幅降低性能，非必要尽量使用协程和委托
        /// </summary>
        public virtual void Update()
        {

        }

        /// <summary>
        /// 释放
        /// </summary>
        private void Destroy()
        {
            self.Destroy();
            self = null;
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            Destroy();
            GameInit.Init.UpdateAction -= Update;
            GC.SuppressFinalize(this);
        }

        ~PageModel()
        {
            Dispose();
        }

        /// <summary>
        /// 创建UI
        /// </summary>
        /// <typeparam name="U">继承PageModel的类</typeparam>
        /// <returns>PageModel</returns>
        public static void CreateAnsy<U>() where U : PageModel<T>, new()
        {
            var Model = new U();
            Model.ShowUIAnsy();
        }

        /// <summary>
        /// 创建UI
        /// </summary>
        /// <typeparam name="U">继承PageModel的类</typeparam>
        /// <returns>PageModel</returns>
        public static void CreateAnsy<U>(Action<U> Ansy) where U : PageModel<T>, new()
        {
            var Model = new U();
            Model.ShowUIAnsy((obj) =>
            {
                Ansy?.Invoke(Model);
            });
        }

        /// <summary>
        /// 创建UI
        /// </summary>
        /// <typeparam name="U">继承PageModel的类</typeparam>
        /// <returns>PageModel</returns>
        public static void CreateAnsy<U>(Action Ansy = null) where U : PageModel<T>, new()
        {
            var Model = new U();
            Model.ShowUIAnsy((obj) =>
            {
                Ansy?.Invoke();
            });
        }

        /// <summary>
        /// 创建UI
        /// </summary>
        /// <typeparam name="U">继承PageModel的类</typeparam>
        /// <returns>PageModel</returns>
        public static void CreateAnsy<U>(GameObject parent) where U : PageModel<T>, new()
        {
            var Model = new U();
            Model.ShowUIAnsy(parent);
        }

        /// <summary>
        /// 创建UI
        /// </summary>
        /// <typeparam name="U">继承PageModel的类</typeparam>
        /// <returns>PageModel</returns>
        public static void CreateAnsy<U>(GameObject parent, Action<U> Ansy = null) where U : PageModel<T>, new()
        {
            var Model = new U();
            Model.ShowUIAnsy(parent, (obj) =>
            {
                Ansy?.Invoke(Model);
            });
        }

        /// <summary>
        /// 创建UI
        /// </summary>
        /// <typeparam name="U">继承PageModel的类</typeparam>
        /// <returns>PageModel</returns>
        public static void CreateAnsy<U>(GameObject parent, Action Ansy = null) where U : PageModel<T>, new()
        {
            var Model = new U();
            Model.ShowUIAnsy(parent, (obj) =>
            {
                Ansy?.Invoke();
            });
        }


        /// <summary>
        /// 创建UI
        /// </summary>
        /// <typeparam name="U">PageBase</typeparam>
        /// <returns>PageBase实例</returns>
        public static void CreateUIAnsy<U>(Action<U> Ansy) where U : PageBase<U>
        {
            PageBase<U>.CreateAnsy((obj) =>
            {
                Ansy?.Invoke(obj);
            });
        }


        /// <summary>
        /// 创建UI
        /// </summary>
        /// <typeparam name="U">PageBase</typeparam>
        /// <param name="parent">父对象</param>
        /// <returns>PageBase实例</returns>
        public static void CreateUIAnsy<U>(GameObject parent, Action<U> Ansy) where U : PageBase<U>
        {
            PageBase<U>.CreateAnsy(parent, (obj) =>
            {
                Ansy?.Invoke(obj);
            });
        }

    }

}