//============================这是一段自动生成代码==============================
//如果报错请删除文件重新生成，请注意命名规范
using UnityEngine.AddressableAssets;
namespace GameUI {
	public class UI_Top : Framework.PageBase<UI_Top>
	{
		private UnityEngine.RectTransform _RectTransform;
		public UnityEngine.RectTransform RectTransform { get => _RectTransform ??= UI.GetComponent<UnityEngine.RectTransform>(); }
		private UnityEngine.UI.Button _Button;
		public UnityEngine.UI.Button Button { get => _Button ??= UI.GetComponent<UnityEngine.UI.Button>(); }
		//============================子对象==============================
		public UI_TopImage _UI_TopImage;
		public UI_TopImage UI_TopImage{ get => _UI_TopImage ??= UI_TopImage.CreateSubobject(UI.transform.GetChild(0).gameObject); }
		public UI_SilverCoin _UI_SilverCoin;
		public UI_SilverCoin UI_SilverCoin{ get => _UI_SilverCoin ??= UI_SilverCoin.CreateSubobject(UI.transform.GetChild(1).gameObject); }
		public UI_Gemstone _UI_Gemstone;
		public UI_Gemstone UI_Gemstone{ get => _UI_Gemstone ??= UI_Gemstone.CreateSubobject(UI.transform.GetChild(2).gameObject); }
		public UI_OptionButton _UI_OptionButton;
		public UI_OptionButton UI_OptionButton{ get => _UI_OptionButton ??= UI_OptionButton.CreateSubobject(UI.transform.GetChild(3).gameObject); }
		public UI_BackButton _UI_BackButton;
		public UI_BackButton UI_BackButton{ get => _UI_BackButton ??= UI_BackButton.CreateSubobject(UI.transform.GetChild(4).gameObject); }
	}
}
