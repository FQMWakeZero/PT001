
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    public static GameInit Init;
    private void Awake()
    {
        Init = this;
    }

    
    private void Start()
    {
        LoadingModel.CreateAnsy<LoadingModel>();

    }

    public Action UpdateAction;
    private void Update()
    {
        UpdateAction?.Invoke();
    }
}
