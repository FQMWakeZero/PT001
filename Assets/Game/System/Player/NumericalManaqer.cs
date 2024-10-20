using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数值管理器
/// </summary>
public class NumericalManaqer
{
    public Dictionary<Numer, string> pairs = new Dictionary<Numer, string>();

    [NonSerializedAttribute]
    private Dictionary<Numer, Action<object>> ActionUpData = new Dictionary<Numer, Action<object>>();

    public NumericalManaqer AddUpData<T>(Numer Key, Action<T> action)
    {
        Action<object> wrappedAction = (obj) => action((T)obj);
        action?.Invoke(GetValue<T>(Key));   //添加订阅

        if (FindAct(Key))
        {
            // 添加到现有的Action链中
            ActionUpData[Key] += wrappedAction;
        }
        else
        {
            // 新增Action
            ActionUpData.Add(Key, wrappedAction);
        }
        return this;
    }

    public NumericalManaqer RemoveUpData<T>(Numer Key, Action<T> action)
    {
        if (FindAct(Key))
        {
            Action<object> wrappedAction = (obj) => action((T)obj);
            ActionUpData[Key] -= wrappedAction;
            if (ActionUpData[Key] == null)
            {
                ActionUpData.Remove(Key);   //移除订阅
            }
        }
        return this;
    }

    #region SetValue方法 AddValue方法 GetValue方法
    public NumericalManaqer SetValue<T>(Numer Key, T Value)
    {
        if (Find(Key))
        {
            var V = pairs[Key];
            pairs[Key] = Value.ToString();
            if (FindAct(Key))
                ActionUpData[Key]?.Invoke(V);
        }
        else
        {
            pairs.Add(Key, Value.ToString());
            if (FindAct(Key))
                ActionUpData[Key]?.Invoke(null);
        }
        return this;
    }

    public NumericalManaqer AddValue<T>(Numer Key, T Value)
    {
        if (Find(Key))
        {
            Type itemType = typeof(T);

            if (itemType == typeof(int))
            {
                int A = int.Parse(pairs[Key]);
                pairs[Key] = (A + (int)(object)Value).ToString();
                if (FindAct(Key))
                    ActionUpData[Key]?.Invoke(A);
            }
            if (itemType == typeof(long))
            {
                long A = long.Parse(pairs[Key]);
                pairs[Key] = (A + (long)(object)Value).ToString();
                if (FindAct(Key))
                    ActionUpData[Key]?.Invoke(A);
            }
            else if (itemType == typeof(float))
            {
                float B = float.Parse(pairs[Key]);
                pairs[Key] = (B + (float)(object)Value).ToString();
                if (FindAct(Key))
                    ActionUpData[Key]?.Invoke(B);
            }
            else if (itemType == typeof(string))
            {
                SetValue(Key, Value);
            }
            else if (itemType == typeof(bool))
            {
                bool D = bool.Parse(pairs[Key]);
                pairs[Key] = Value.ToString();
                if (FindAct(Key))
                    ActionUpData[Key]?.Invoke(D);
            }
        }
        else
        {
            SetValue(Key, Value);
        }
        return this;
    }

    public T GetValue<T>(Numer Key)
    {
        Type itemType = typeof(T);
        object Value = null;

        if (Find(Key))
        {
            if (itemType == typeof(int))
            {
                Value = int.Parse(pairs[Key]);
            }
            else if (itemType == typeof(long))
            {
                Value = long.Parse(pairs[Key]);
            }
            else if (itemType == typeof(float))
            {
                Value = float.Parse(pairs[Key]);
            }
            else if (itemType == typeof(string))
            {
                Value = pairs[Key];
            }
            else if (itemType == typeof(bool))
            {
                Value = bool.Parse(pairs[Key]);
            }
            else if (itemType == typeof(double))
            {
                Value = double.Parse(pairs[Key]);
            }
            else
            {
                Debug.LogError($"NumericalManager.GetValue<T>()中出现无可返回的类型");
            }
        }
        else
        {
            //初始化数据
            if (itemType == typeof(int))
            {
                SetValue(Key, 0);
                Value = 0;
            }
            else if (itemType == typeof(long))
            {
                SetValue(Key, 0L);
                Value = 0L;
            }
            else if (itemType == typeof(float))
            {
                SetValue(Key, 0.00f);
                Value = 0.00f;
            }
            else if (itemType == typeof(string))
            {
                SetValue<string>(Key, null);
                Value = null;
            }
            else if (itemType == typeof(bool))
            {
                SetValue(Key, false);
                Value = false;
            }
            else if (itemType == typeof(double))
            {
                SetValue(Key, 0.0);
                Value = 0.0;
            }
            else
            {
                Debug.LogError($"NumericalManager.GetValue<T>()中出现无可返回的类型");
            }
        }

        return (T)Value;
    }


    private bool Find(Numer Key)
    {
        foreach (var item in pairs)
        {
            if (item.Key == Key)
                return true;
        }
        return false;
    }

    private bool FindAct(Numer Key)
    {
        foreach (var item in ActionUpData)
        {
            if (item.Key == Key)
                return true;
        }
        return false;
    }

    #endregion
    public NumericalManaqer()
    {
        //初始化基础数据
        SetValue(Numer.SilverCoin, 0);
        SetValue(Numer.Gemstone, 0);
    }
}

public enum Numer
{
    /// <summary>
    /// 银币
    /// </summary>
    SilverCoin,
    /// <summary>
    /// 宝石
    /// </summary>
    Gemstone,
}