//============================这是一段自动生成代码==============================
//如果报错请删除文件重新生成，请注意命名规范
using UnityEngine.AddressableAssets;
namespace GameUI {
	public class UI_Game : Framework.PageBase<UI_Game>
	{
		private UnityEngine.RectTransform _RectTransform;
		public UnityEngine.RectTransform RectTransform { get => _RectTransform ??= UI.GetComponent<UnityEngine.RectTransform>(); }
		private UnityEngine.CanvasRenderer _CanvasRenderer;
		public UnityEngine.CanvasRenderer CanvasRenderer { get => _CanvasRenderer ??= UI.GetComponent<UnityEngine.CanvasRenderer>(); }
		private UnityEngine.UI.Image _Image;
		public UnityEngine.UI.Image Image { get => _Image ??= UI.GetComponent<UnityEngine.UI.Image>(); }
		//============================子对象==============================
		public UI_Items _UI_Items;
		public UI_Items UI_Items{ get => _UI_Items ??= UI_Items.CreateSubobject(UI.transform.GetChild(0).gameObject); }
		public UI_Track _UI_Track;
		public UI_Track UI_Track{ get => _UI_Track ??= UI_Track.CreateSubobject(UI.transform.GetChild(1).gameObject); }
	}
}
