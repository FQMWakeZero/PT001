using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECSFrame;
using LoadGamePack;

public class Init : MonoBehaviour
{
    public static Init init;
    
    void Start()
    {
        init = this;

        ResourcesManager.Load();

        LoadGameCom.CreateInstance().ShowUI(LoadGameSystem.init);

    }

    
    void Update()
    {
        
    }
}
