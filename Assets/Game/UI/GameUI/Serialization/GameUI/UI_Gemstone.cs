//============================这是一段自动生成代码==============================
//如果报错请删除文件重新生成，请注意命名规范
using UnityEngine.AddressableAssets;
namespace GameUI {
	public class UI_Gemstone : Framework.PageBase<UI_Gemstone>
	{
		private UnityEngine.RectTransform _RectTransform;
		public UnityEngine.RectTransform RectTransform { get => _RectTransform ??= UI.GetComponent<UnityEngine.RectTransform>(); }
		private UnityEngine.CanvasRenderer _CanvasRenderer;
		public UnityEngine.CanvasRenderer CanvasRenderer { get => _CanvasRenderer ??= UI.GetComponent<UnityEngine.CanvasRenderer>(); }
		private UnityEngine.UI.Image _Image;
		public UnityEngine.UI.Image Image { get => _Image ??= UI.GetComponent<UnityEngine.UI.Image>(); }
		//============================子对象==============================
		public UI_GemstoneText _UI_GemstoneText;
		public UI_GemstoneText UI_GemstoneText{ get => _UI_GemstoneText ??= UI_GemstoneText.CreateSubobject(UI.transform.GetChild(0).gameObject); }
	}
}
