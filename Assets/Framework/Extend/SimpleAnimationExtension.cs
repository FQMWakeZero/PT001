using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class SimpleAnimationExtension
{
    /// <summary>
    /// 按钮缩小动画，缩小后变大
    /// 
    /// </summary>
    /// <param name="Button"></param>
    public static void ButtonShrink(this Button Button)
    {
        Button.transform.DOScale(0.85f, 0.15f).onComplete = () =>
        {
            Button.transform.DOScale(1f, 0.15f);
        };
    }
    /// <summary>
    /// 按钮缩小动画，缩小后变大，带注册点击事件
    /// </summary>
    /// <param name="Button"></param>
    /// <param name="Click"></param>
    public static void ButtonShrink(this Button Button,Action Click)
    {
        Button.onClick.AddListener(() =>
        {
            Click?.Invoke();
            Button.ButtonShrink();
        });
    }
}
