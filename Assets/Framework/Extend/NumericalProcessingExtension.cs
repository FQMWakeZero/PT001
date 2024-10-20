using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NumericalProcessingExtension
{
    /// <summary>
    /// 转换数值单位
    /// </summary>
    /// <param name="value">输入的长整型数值</param>
    /// <returns>转换后的字符串，带有相应单位</returns>
    public static string Units(this long value, int digit = 1)
    {
        //string[] unitList = new string[] { "", "K", "M" };


        //float tempNum = value;
        //long v = 1000;//几位一个单位
        //int unitIndex = 0;
        //while (tempNum >= v)
        //{
        //    unitIndex++;
        //    tempNum /= v;
        //}

        //string str = "";
        //if (unitIndex >= unitList.Length)
        //{
        //    Debug.LogError("超出单位表中的最大单位");
        //    str = value.ToString();
        //}
        //else
        //{
        //    tempNum = Round(tempNum, digit);
        //    str = $"{tempNum}{unitList[unitIndex]}";
        //}
        //return str;

        //float Round(float value, int digits = 1)
        //{
        //    float multiple = Mathf.Pow(10, digits);
        //    float tempValue = value * multiple + 0.5f;
        //    tempValue = Mathf.FloorToInt(tempValue);
        //    return tempValue / multiple;
        //}

        return value.ToString();
    }
}
