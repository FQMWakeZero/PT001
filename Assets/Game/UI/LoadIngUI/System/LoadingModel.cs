using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;
using LoadIngUI;
using DG.Tweening;
using System;
using System.Reflection;
using System.Linq;

public class LoadingModel : PageModel<UI_LoadIngUI>
{
    public override void Awake()
    {
        
        GameInit.Init.StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        self.UI_LoadingBack.UI_LoadingBar.Image.fillAmount = 0;
        self.UI_LoadingBack.UI_LoadingBar.Image.DOFillAmount(1, 3);

        _ = PlayerData.init;
        yield return new WaitForSeconds(1.5f);
        LoadConfig();
        yield return new WaitForSeconds(1.5f);

        MainGameUIModel.CreateAnsy<MainGameUIModel>(() =>
        {
            
            Dispose();
        });
    }

    /// <summary>
    /// 反射加载所有配置表
    /// </summary>
    private void LoadConfig()
    {
        List<Type> typesInNamespace = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "GameModel");

        foreach (var type in typesInNamespace)
        {
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);

            foreach (var method in methods)
                if(method.Name == "LoadConfig")
                    method.Invoke(null, null);
        }
    }

    private static List<Type> GetTypesInNamespace(Assembly assembly, string namespaceName)
    {
        return assembly.GetTypes()
                       .Where(t => t.Namespace == namespaceName)
                       .ToList();
    }
    public static void CallMethodByName(string typeName, string methodName, object[] parameters)
    {
        Type type = Type.GetType(typeName);
        if (type == null)
        {
            Console.WriteLine($"类型 {typeName} 不存在.");
            return;
        }
        object instance = Activator.CreateInstance(type);
        MethodInfo method = type.GetMethod(methodName);
        if (method == null)
        {
            Console.WriteLine($"方法 {methodName} 不存在 {typeName}.");
            return;
        }
        method.Invoke(instance, parameters);
    }
}
