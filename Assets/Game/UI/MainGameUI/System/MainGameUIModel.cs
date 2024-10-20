
using Framework;
using MainGameUI;
public class MainGameUIModel : PageModel<UI_MainGameUI>
{
    public override void Awake()
    {
        //���Ҷ���
        PlayerData.init.numericalManaqer.AddUpData<long>(Numer.SilverCoin, (value) =>
        {
            self.UI_Head.UI_SilverCoin.UI_SilverCoinText.TextMeshProUGUI.text = PlayerData.init.numericalManaqer.GetValue<string>(Numer.SilverCoin);
        });

        //��ʯ����
        PlayerData.init.numericalManaqer.AddUpData<long>(Numer.Gemstone, (value) =>
        {
            self.UI_Head.UI_Gemstone.UI_GemstoneText.TextMeshProUGUI.text = PlayerData.init.numericalManaqer.GetValue<string>(Numer.Gemstone);
        });


        //���Ұ�ť
        self.UI_Head.UI_SilverCoin.Button.ButtonShrink(() =>
        {

        });

        //��ʯ��ť
        self.UI_Head.UI_Gemstone.Button.ButtonShrink(() =>
        {

        });

        //���ð�ť
        self.UI_Head.UI_OptionButton.Button.ButtonShrink(() =>
        {

        });

        //��ʼ��Ϸ��ť
        self.UI_PlayGameButton.Button.ButtonShrink(() =>
        {
            GameUIModel.CreateAnsy<GameUIModel>();
        });
    }
}
