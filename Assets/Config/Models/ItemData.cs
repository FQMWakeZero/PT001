using Newtonsoft.Json;
using UnityEngine;
using System;
using System.Collections.Generic;
using Framework;
//这是自动生成的代码，请勿修改
namespace GameModel
{
   public class ItemData
    {
       private static ItemData init;
       public static ItemData Init
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
           AssetsManager<TextAsset>.Init.LoadAssetAsync("ItemData", (Assets) =>
           {
               ItemData ItemData = new ItemData
               {
                   root = JsonConvert.DeserializeObject<List<ItemDataSubobject>>(Assets.text)
               };
               init = ItemData;
               Debug.Log("配置表 [ ItemData ] 已加载完毕");
           });
       }
       public ItemDataSubobject find(string ID)
       {
           foreach (var item in root)
               if (item.ID == ID)
                   return item;
           return null;
       }
       public List<ItemDataSubobject> root { get; set; }
   }
   public static class ItemDataExtend
   {
       public static ItemDataSubobject ToItemData(this string id) => ItemData.Init.find(id);
   }
   public class ItemDataSubobject
   {
       /// <summary>
       /// 实体的ID，如果值为空就是过了最后一个
       /// </summary>
       public String ID { get; set; }
       /// <summary>
       /// 图标ID
       /// </summary>
       public String SpriteID { get; set; }
       /// <summary>
       /// 拖尾颜色
       /// </summary>
       public Int32[] TrailColors_RGB { get; set; }
       /// <summary>
       /// 拖尾终点颜色
       /// </summary>
       public Int32[] TrailEnd_RGB { get; set; }
   }
}
