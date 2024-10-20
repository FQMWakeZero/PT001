using Newtonsoft.Json;
using UnityEngine;
using System;
using System.Collections.Generic;
using Framework;
//这是自动生成的代码，请勿修改
namespace GameModel
{
   public class Test
    {
       private static Test init;
       public static Test Init
       {
           get
           {
               if (init != null) return init;
               Debug.LogError("错误：你需要提前加载该配置，不允许在未加载的情况下使用");
               return null;
           }
       }
       public static void LoadConfig()
       {
           AssetsManager<TextAsset>.Init.LoadAssetAsync("Test", (Assets) =>
           {
               Test Test = new Test
               {
                   root = JsonConvert.DeserializeObject<List<TestSubobject>>(Assets.text)
               };
               init = Test;
               Debug.Log("配置表 [ Test ] 已加载完毕");
           });
       }
       public TestSubobject find(string ID)
       {
           foreach (var item in root)
               if (item.ID == ID)
                   return item;
           return null;
       }
       public List<TestSubobject> root { get; set; }
   }
   public static class TestExtend
   {
       public static TestSubobject ToTest(this string id) => Test.Init.find(id);
   }
   public class TestSubobject
   {
       /// <summary>
       /// 唯一键
       /// </summary>
       public String ID { get; set; }
       /// <summary>
       /// 物品名称
       /// </summary>
       public String[] Name { get; set; }
       /// <summary>
       /// 数量
       /// </summary>
       public Int32 Num { get; set; }
       /// <summary>
       /// 多个数量
       /// </summary>
       public Int32[] Nums { get; set; }
       /// <summary>
       /// 浮点数
       /// </summary>
       public Single test { get; set; }
       /// <summary>
       /// 浮点数数组
       /// </summary>
       public Single[] test2 { get; set; }
       /// <summary>
       /// 布尔
       /// </summary>
       public Boolean test3 { get; set; }
       /// <summary>
       /// 布尔数组
       /// </summary>
       public Boolean[] test4 { get; set; }
   }
}
