//============================这是一段自动生成代码==============================
//如果报错请删除文件重新生成，请注意命名规范
using UnityEngine.AddressableAssets;
namespace GameUI {
	public class UI_GameUI : Framework.PageBase<UI_GameUI>
	{
		private UnityEngine.RectTransform _RectTransform;
		public UnityEngine.RectTransform RectTransform { get => _RectTransform ??= UI.GetComponent<UnityEngine.RectTransform>(); }
		//============================子对象==============================
		public UI_Background _UI_Background;
		public UI_Background UI_Background{ get => _UI_Background ??= UI_Background.CreateSubobject(UI.transform.GetChild(0).gameObject); }
		public UI_Game _UI_Game;
		public UI_Game UI_Game{ get => _UI_Game ??= UI_Game.CreateSubobject(UI.transform.GetChild(1).gameObject); }
		public UI_Top _UI_Top;
		public UI_Top UI_Top{ get => _UI_Top ??= UI_Top.CreateSubobject(UI.transform.GetChild(2).gameObject); }
		public UI_Buttn _UI_Buttn;
		public UI_Buttn UI_Buttn{ get => _UI_Buttn ??= UI_Buttn.CreateSubobject(UI.transform.GetChild(3).gameObject); }
		public static string Path = "Assets/Game/UI/GameUI/GameUI.prefab";
	}
}
