using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class UISerialization : MonoBehaviour
{
    [MenuItem("Assets/生成UI序列化", true)]
    private static bool ValidateDoSomethingWithPrefab()
    {
        // 确保选中的对象是一个预制体
        if (Selection.objects.Length == 0) return false;
        foreach (Object obj in Selection.objects)
        {
            if (PrefabUtility.GetPrefabAssetType(obj) == PrefabAssetType.NotAPrefab)
                return false;
        }
        return true;
    }

    [MenuItem("Assets/生成UI序列化")]
    private static void DoSomethingWithPrefab()
    {
        // 获取选中的对象
        List<GameObject> selectedObjects = Selection.objects
                    .Where(obj => obj is GameObject)
                    .Cast<GameObject>()
                    .ToList();
        Create(selectedObjects.ToList());


    }

    private static void Create(List<GameObject> objects)
    {
        foreach (var item in objects)
        {
            _Create(item, item.name, false);
            AssetDatabase.Refresh();
        }
    }

    private static void _Create(GameObject item, string namespaces, bool IsCchildObject)
    {
        if (item.name == "GameObject")
            Debug.LogError($"有一个预制体的名称为GameObject这是命名规范错误，请检查:{namespaces}");

        Directory.CreateDirectory(Path.GetDirectoryName(Application.dataPath) + $"/{Path.GetDirectoryName(AssetDatabase.GetAssetPath(item))}/Serialization/{namespaces}");
        StreamWriter file = new StreamWriter(new FileStream(Path.GetDirectoryName(Application.dataPath) + $"/{Path.GetDirectoryName(AssetDatabase.GetAssetPath(item))}" + $"/Serialization/{namespaces}/UI_{item.name}.cs", FileMode.Create), Encoding.UTF8);

        var _path = $"{Path.GetDirectoryName(AssetDatabase.GetAssetPath(item))}";
        _path = _path.Replace("\\", "/");

        file.WriteLine("//============================这是一段自动生成代码==============================");
        file.WriteLine("//如果报错请删除文件重新生成，请注意命名规范");
        file.WriteLine("using UnityEngine.AddressableAssets;");

        file.WriteLine($"namespace {namespaces} {{");
        file.WriteLine($"\tpublic class UI_{item.name} : Framework.PageBase<UI_{item.name}>");
        file.WriteLine($"\t{{");
        foreach (var item_1 in item.GetComponents(typeof(Component)))
        {
            file.WriteLine($"\t\tprivate {item_1.GetType()} _{item_1.GetType().Name};");

            file.WriteLine($"\t\tpublic {item_1.GetType()} {item_1.GetType().Name} {{ get => _{item_1.GetType().Name} ??= UI.GetComponent<{item_1.GetType()}>(); }}");
        }
        if (item.transform.childCount != 0)
            file.WriteLine("\t\t//============================子对象==============================");

        int Index = 0;
        foreach (Transform child in item.transform)
        {
            file.WriteLine($"\t\tpublic UI_{child.name} _UI_{child.name};");

            file.WriteLine($"\t\tpublic UI_{child.name} UI_{child.name}{{ get => _UI_{child.name} ??= UI_{child.name}.CreateSubobject(UI.transform.GetChild({Index}).gameObject); }}");
            Index++;
        }

        if (!IsCchildObject)
            file.WriteLine($"\t\tpublic static string Path = \"{_path}/{item.name}.prefab\";");

        //file.WriteLine($"\t\tprivate void Awake()");
        //file.WriteLine($"\t\t{{");
        //file.WriteLine($"\t\t\tUI = gameObject;");
        //foreach (var item_2 in item.GetComponents(typeof(Component)))
        //{
        //    file.WriteLine($"\t\t\t{item_2.GetType().Name} = UI.GetComponent<{item_2.GetType()}>();");
        //}
        //int Index = 0;
        //foreach (Transform child in item.transform)
        //{
        //    file.WriteLine($"\t\t\tUI_{child.name} = UI_{child.name}.CreateSubobject(UI.transform.GetChild({Index}).gameObject);");
        //    Index++;
        //}
        //file.WriteLine($"\t\t}}");


        file.WriteLine($"\t}}");
        file.WriteLine($"}}");
        file.Close();
        foreach (Transform child in item.transform)
        {
            _Create(child.gameObject, namespaces, true);
        }
    }
}
