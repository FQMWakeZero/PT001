using FairyGUI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ECSFrame
{
    public class UIManager
    {
        private static UIManager _Init;
        public static UIManager Init { get { if (_Init == null) _Init = new UIManager(); return _Init; } }

        public Dictionary<UI, GComponent> UIList = new Dictionary<UI, GComponent>();

        public GComponent Show(GComponent FUI)
        {
            FUI = (GComponent)GRoot.inst.AddChild(FUI);
            FUI.MakeFullScreen();
            return FUI;
        }
        /// <summary>
        /// 你需要采用这种Dispose方式以满足管理器需要
        /// </summary>
        /// <param name="System"></param>
        public void Dispose(ISystem System)
        {
            if (UIList.ContainsKey(System))
            {
                UIList[System].Dispose();
                UIList.Remove(System);
            }
        }
        /// <summary>
        /// 你需要采用这种Dispose方式以满足管理器需要
        /// </summary>
        /// <param name="System"></param>
        public void Dispose(FullUIInterface System)
        {
            if (UIList.ContainsKey(System))
            {
                UIList[System].Dispose();
                UIList.Remove(System);
            }
        }
    }

    public static class StaticUIManager
    {
        public static void ShowUI(this GComponent FUI, ISystem System)
        {
            if (!UIManager.Init.UIList.ContainsKey(System))
            {
                UIManager.Init.UIList.Add(System, FUI);
                FUI = UIManager.Init.Show(FUI);
                System.Start(FUI);
            }
        }

        public static void ShowUI(this GComponent FUI, FullUIInterface System)
        {
            if (!UIManager.Init.UIList.ContainsKey(System))
            {
                UIManager.Init.UIList.Add(System, FUI);
                FUI = UIManager.Init.Show(FUI);
                System.Start(FUI);
            }
        }
    }

}


