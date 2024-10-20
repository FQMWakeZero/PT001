//============================这是一段自动生成代码==============================
//如果报错请删除文件重新生成，请注意命名规范
using UnityEngine.AddressableAssets;
namespace ItemGame {
	public class UI_ItemGame : Framework.PageBase<UI_ItemGame>
	{
		private UnityEngine.RectTransform _RectTransform;
		public UnityEngine.RectTransform RectTransform { get => _RectTransform ??= UI.GetComponent<UnityEngine.RectTransform>(); }
		private UnityEngine.EventSystems.EventTrigger _EventTrigger;
		public UnityEngine.EventSystems.EventTrigger EventTrigger { get => _EventTrigger ??= UI.GetComponent<UnityEngine.EventSystems.EventTrigger>(); }
		//============================子对象==============================
		public UI_ItemBack _UI_ItemBack;
		public UI_ItemBack UI_ItemBack{ get => _UI_ItemBack ??= UI_ItemBack.CreateSubobject(UI.transform.GetChild(0).gameObject); }
		public UI_TransitionalBackground _UI_TransitionalBackground;
		public UI_TransitionalBackground UI_TransitionalBackground{ get => _UI_TransitionalBackground ??= UI_TransitionalBackground.CreateSubobject(UI.transform.GetChild(1).gameObject); }
		public UI_ItemNumber _UI_ItemNumber;
		public UI_ItemNumber UI_ItemNumber{ get => _UI_ItemNumber ??= UI_ItemNumber.CreateSubobject(UI.transform.GetChild(2).gameObject); }
		public UI_Trail _UI_Trail;
		public UI_Trail UI_Trail{ get => _UI_Trail ??= UI_Trail.CreateSubobject(UI.transform.GetChild(3).gameObject); }
		public static string Path = "Assets/Game/UI/GameUI/ItemGame.prefab";
	}
}
