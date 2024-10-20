//============================这是一段自动生成代码==============================
//如果报错请删除文件重新生成，请注意命名规范
using UnityEngine.AddressableAssets;
namespace MainGameUI {
	public class UI_MainGameUI : Framework.PageBase<UI_MainGameUI>
	{
		private UnityEngine.RectTransform _RectTransform;
		public UnityEngine.RectTransform RectTransform { get => _RectTransform ??= UI.GetComponent<UnityEngine.RectTransform>(); }
		//============================子对象==============================
		public UI_Background  _UI_Background ;
		public UI_Background  UI_Background { get => _UI_Background  ??= UI_Background .CreateSubobject(UI.transform.GetChild(0).gameObject); }
		public UI_Head _UI_Head;
		public UI_Head UI_Head{ get => _UI_Head ??= UI_Head.CreateSubobject(UI.transform.GetChild(1).gameObject); }
		public UI_GameIcon _UI_GameIcon;
		public UI_GameIcon UI_GameIcon{ get => _UI_GameIcon ??= UI_GameIcon.CreateSubobject(UI.transform.GetChild(2).gameObject); }
		public UI_PlayGameButton _UI_PlayGameButton;
		public UI_PlayGameButton UI_PlayGameButton{ get => _UI_PlayGameButton ??= UI_PlayGameButton.CreateSubobject(UI.transform.GetChild(3).gameObject); }
		public static string Path = "Assets/Game/UI/MainGameUI/MainGameUI.prefab";
	}
}
