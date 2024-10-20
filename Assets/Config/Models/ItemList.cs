using Newtonsoft.Json;
using UnityEngine;
using System;
using System.Collections.Generic;
using Framework;
//这是自动生成的代码，请勿修改
namespace GameModel
{
   public class ItemList
    {
       private static ItemList init;
       public static ItemList Init
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
           AssetsManager<TextAsset>.Init.LoadAssetAsync("ItemList", (Assets) =>
           {
               ItemList ItemList = new ItemList
               {
                   root = JsonConvert.DeserializeObject<List<ItemListSubobject>>(Assets.text)
               };
               init = ItemList;
               Debug.Log("配置表 [ ItemList ] 已加载完毕");
           });
       }
       public ItemListSubobject find(string ID)
       {
           foreach (var item in root)
               if (item.ID == ID)
                   return item;
           return null;
       }
       public List<ItemListSubobject> root { get; set; }
   }
   public static class ItemListExtend
   {
       public static ItemListSubobject ToItemList(this string id) => ItemList.Init.find(id);
   }
   public class ItemListSubobject
   {
       /// <summary>
       /// 唯一键
       /// </summary>
       public String ID { get; set; }
       /// <summary>
       /// 物品名称
       /// </summary>
       public String Name { get; set; }
       /// <summary>
       /// 物品的标签(TagTable表)
       /// </summary>
       public String[] Tag { get; set; }
       /// <summary>
       /// 物品重量
       /// </summary>
       public Int32 Weight { get; set; }
       /// <summary>
       /// 占用大小(宽度 * 高度)
       /// </summary>
       public Int32[] Size { get; set; }
       /// <summary>
       /// 合成方式(为null则为不可合成)
       /// </summary>
       public String[] Synthesis { get; set; }
       /// <summary>
       /// 合成后基于数量，不可合成则忽略
       /// </summary>
       public Int32 Number { get; set; }
       /// <summary>
       /// 建造条件，为null为可以手搓（ConstructionTable表）
       /// </summary>
       public String[] Condition { get; set; }
       /// <summary>
       /// 实体表(EntityTable表)
       /// </summary>
       public String Object { get; set; }
   }
}
