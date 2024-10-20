using Newtonsoft.Json;
using UnityEngine;
using System;
using System.Collections.Generic;
using Framework;
//这是自动生成的代码，请勿修改
namespace GameModel
{
   public class EntityTable
    {
       private static EntityTable init;
       public static EntityTable Init
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
           AssetsManager<TextAsset>.Init.LoadAssetAsync("EntityTable", (Assets) =>
           {
               EntityTable EntityTable = new EntityTable
               {
                   root = JsonConvert.DeserializeObject<List<EntityTableSubobject>>(Assets.text)
               };
               init = EntityTable;
               Debug.Log("配置表 [ EntityTable ] 已加载完毕");
           });
       }
       public EntityTableSubobject find(string ID)
       {
           foreach (var item in root)
               if (item.ID == ID)
                   return item;
           return null;
       }
       public List<EntityTableSubobject> root { get; set; }
   }
   public static class EntityTableExtend
   {
       public static EntityTableSubobject ToEntityTable(this string id) => EntityTable.Init.find(id);
   }
   public class EntityTableSubobject
   {
       /// <summary>
       /// 实体的ID
       /// </summary>
       public String ID { get; set; }
       /// <summary>
       /// 实体的图标路径
       /// </summary>
       public String Spirit { get; set; }
       /// <summary>
       /// 实体的预制体路径
       /// </summary>
       public String Preform { get; set; }
   }
}
