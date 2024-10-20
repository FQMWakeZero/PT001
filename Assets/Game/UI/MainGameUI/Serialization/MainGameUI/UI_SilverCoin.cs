//============================这是一段自动生成代码==============================
//如果报错请删除文件重新生成，请注意命名规范
using UnityEngine.AddressableAssets;
namespace MainGameUI {
	public class UI_SilverCoin : Framework.PageBase<UI_SilverCoin>
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
		public UI_SilverCoinText _UI_SilverCoinText;
		public UI_SilverCoinText UI_SilverCoinText{ get => _UI_SilverCoinText ??= UI_SilverCoinText.CreateSubobject(UI.transform.GetChild(0).gameObject); }
	}
}
