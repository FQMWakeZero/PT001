//============================这是一段自动生成代码==============================
//如果报错请删除文件重新生成，请注意命名规范
using UnityEngine.AddressableAssets;
namespace MainGameUI {
	public class UI_Head : Framework.PageBase<UI_Head>
	{
		private UnityEngine.RectTransform _RectTransform;
		public UnityEngine.RectTransform RectTransform { get => _RectTransform ??= UI.GetComponent<UnityEngine.RectTransform>(); }
		private UnityEngine.UI.HorizontalLayoutGroup _HorizontalLayoutGroup;
		public UnityEngine.UI.HorizontalLayoutGroup HorizontalLayoutGroup { get => _HorizontalLayoutGroup ??= UI.GetComponent<UnityEngine.UI.HorizontalLayoutGroup>(); }
		private UnityEngine.UI.ContentSizeFitter _ContentSizeFitter;
		public UnityEngine.UI.ContentSizeFitter ContentSizeFitter { get => _ContentSizeFitter ??= UI.GetComponent<UnityEngine.UI.ContentSizeFitter>(); }
		//============================子对象==============================
		public UI_SilverCoin _UI_SilverCoin;
		public UI_SilverCoin UI_SilverCoin{ get => _UI_SilverCoin ??= UI_SilverCoin.CreateSubobject(UI.transform.GetChild(0).gameObject); }
		public UI_Gemstone _UI_Gemstone;
		public UI_Gemstone UI_Gemstone{ get => _UI_Gemstone ??= UI_Gemstone.CreateSubobject(UI.transform.GetChild(1).gameObject); }
		public UI_OptionButton _UI_OptionButton;
		public UI_OptionButton UI_OptionButton{ get => _UI_OptionButton ??= UI_OptionButton.CreateSubobject(UI.transform.GetChild(2).gameObject); }
	}
}
