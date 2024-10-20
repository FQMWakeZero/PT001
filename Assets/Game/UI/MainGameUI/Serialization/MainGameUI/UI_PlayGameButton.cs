//============================这是一段自动生成代码==============================
//如果报错请删除文件重新生成，请注意命名规范
using UnityEngine.AddressableAssets;
namespace MainGameUI {
	public class UI_PlayGameButton : Framework.PageBase<UI_PlayGameButton>
	{
		private UnityEngine.RectTransform _RectTransform;
		public UnityEngine.RectTransform RectTransform { get => _RectTransform ??= UI.GetComponent<UnityEngine.RectTransform>(); }
		private UnityEngine.CanvasRenderer _CanvasRenderer;
		public UnityEngine.CanvasRenderer CanvasRenderer { get => _CanvasRenderer ??= UI.GetComponent<UnityEngine.CanvasRenderer>(); }
		private UnityEngine.UI.Button _Button;
		public UnityEngine.UI.Button Button { get => _Button ??= UI.GetComponent<UnityEngine.UI.Button>(); }
		//============================子对象==============================
		public UI_PlayButtonBackground _UI_PlayButtonBackground;
		public UI_PlayButtonBackground UI_PlayButtonBackground{ get => _UI_PlayButtonBackground ??= UI_PlayButtonBackground.CreateSubobject(UI.transform.GetChild(0).gameObject); }
		public UI_PlayButtonText _UI_PlayButtonText;
		public UI_PlayButtonText UI_PlayButtonText{ get => _UI_PlayButtonText ??= UI_PlayButtonText.CreateSubobject(UI.transform.GetChild(1).gameObject); }
	}
}
