//============================这是一段自动生成代码==============================
//如果报错请删除文件重新生成，请注意命名规范
using UnityEngine.AddressableAssets;
namespace GameUI {
	public class UI_Buttn : Framework.PageBase<UI_Buttn>
	{
		private UnityEngine.RectTransform _RectTransform;
		public UnityEngine.RectTransform RectTransform { get => _RectTransform ??= UI.GetComponent<UnityEngine.RectTransform>(); }
		private UnityEngine.CanvasRenderer _CanvasRenderer;
		public UnityEngine.CanvasRenderer CanvasRenderer { get => _CanvasRenderer ??= UI.GetComponent<UnityEngine.CanvasRenderer>(); }
		private UnityEngine.UI.Image _Image;
		public UnityEngine.UI.Image Image { get => _Image ??= UI.GetComponent<UnityEngine.UI.Image>(); }
		private UnityEngine.UI.Button _Button;
		public UnityEngine.UI.Button Button { get => _Button ??= UI.GetComponent<UnityEngine.UI.Button>(); }
		//============================子对象==============================
		public UI_Icon _UI_Icon;
		public UI_Icon UI_Icon{ get => _UI_Icon ??= UI_Icon.CreateSubobject(UI.transform.GetChild(0).gameObject); }
	}
}
