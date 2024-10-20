//============================这是一段自动生成代码==============================
//如果报错请删除文件重新生成，请注意命名规范
using UnityEngine.AddressableAssets;
namespace GameUI {
	public class UI_Track : Framework.PageBase<UI_Track>
	{
		private UnityEngine.RectTransform _RectTransform;
		public UnityEngine.RectTransform RectTransform { get => _RectTransform ??= UI.GetComponent<UnityEngine.RectTransform>(); }
		private UnityEngine.UI.HorizontalLayoutGroup _HorizontalLayoutGroup;
		public UnityEngine.UI.HorizontalLayoutGroup HorizontalLayoutGroup { get => _HorizontalLayoutGroup ??= UI.GetComponent<UnityEngine.UI.HorizontalLayoutGroup>(); }
		private UnityEngine.EventSystems.EventTrigger _EventTrigger;
		public UnityEngine.EventSystems.EventTrigger EventTrigger { get => _EventTrigger ??= UI.GetComponent<UnityEngine.EventSystems.EventTrigger>(); }
		//============================子对象==============================
		public UI_Track_1 _UI_Track_1;
		public UI_Track_1 UI_Track_1{ get => _UI_Track_1 ??= UI_Track_1.CreateSubobject(UI.transform.GetChild(0).gameObject); }
		public UI_Track_2 _UI_Track_2;
		public UI_Track_2 UI_Track_2{ get => _UI_Track_2 ??= UI_Track_2.CreateSubobject(UI.transform.GetChild(1).gameObject); }
		public UI_Track_3 _UI_Track_3;
		public UI_Track_3 UI_Track_3{ get => _UI_Track_3 ??= UI_Track_3.CreateSubobject(UI.transform.GetChild(2).gameObject); }
		public UI_Track_4 _UI_Track_4;
		public UI_Track_4 UI_Track_4{ get => _UI_Track_4 ??= UI_Track_4.CreateSubobject(UI.transform.GetChild(3).gameObject); }
		public UI_Track_5 _UI_Track_5;
		public UI_Track_5 UI_Track_5{ get => _UI_Track_5 ??= UI_Track_5.CreateSubobject(UI.transform.GetChild(4).gameObject); }
	}
}
