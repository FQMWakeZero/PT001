using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NumericalProcessingExtension
{
    /// <summary>
    /// ת����ֵ��λ
    /// </summary>
    /// <param name="value">����ĳ�������ֵ</param>
    /// <returns>ת������ַ�����������Ӧ��λ</returns>
    public static string Units(this long value, int digit = 1)
    {
        //string[] unitList = new string[] { "", "K", "M" };


        //float tempNum = value;
        //long v = 1000;//��λһ����λ
        //int unitIndex = 0;
        //while (tempNum >= v)
        //{
        //    unitIndex++;
        //    tempNum /= v;
        //}

        //string str = "";
        //if (unitIndex >= unitList.Length)
        //{
        //    Debug.LogError("������λ���е����λ");
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
