//============================这是一段自动生成代码==============================
//如果报错请删除文件重新生成，请注意命名规范
using UnityEngine.AddressableAssets;
namespace LoadIngUI {
	public class UI_LoadingBack : Framework.PageBase<UI_LoadingBack>
	{
		private UnityEngine.RectTransform _RectTransform;
		public UnityEngine.RectTransform RectTransform { get => _RectTransform ??= UI.GetComponent<UnityEngine.RectTransform>(); }
		private UnityEngine.CanvasRenderer _CanvasRenderer;
		public UnityEngine.CanvasRenderer CanvasRenderer { get => _CanvasRenderer ??= UI.GetComponent<UnityEngine.CanvasRenderer>(); }
		private UnityEngine.UI.Image _Image;
		public UnityEngine.UI.Image Image { get => _Image ??= UI.GetComponent<UnityEngine.UI.Image>(); }
		//============================子对象==============================
		public UI_LoadingBar _UI_LoadingBar;
		public UI_LoadingBar UI_LoadingBar{ get => _UI_LoadingBar ??= UI_LoadingBar.CreateSubobject(UI.transform.GetChild(0).gameObject); }
	}
}
