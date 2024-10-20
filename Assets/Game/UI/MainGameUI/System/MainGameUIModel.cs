
using Framework;
using MainGameUI;
public class MainGameUIModel : PageModel<UI_MainGameUI>
{
    public override void Awake()
    {
        //银币订阅
        PlayerData.init.numericalManaqer.AddUpData<long>(Numer.SilverCoin, (value) =>
        {
            self.UI_Head.UI_SilverCoin.UI_SilverCoinText.TextMeshProUGUI.text = PlayerData.init.numericalManaqer.GetValue<string>(Numer.SilverCoin);
        });

        //宝石订阅
        PlayerData.init.numericalManaqer.AddUpData<long>(Numer.Gemstone, (value) =>
        {
            self.UI_Head.UI_Gemstone.UI_GemstoneText.TextMeshProUGUI.text = PlayerData.init.numericalManaqer.GetValue<string>(Numer.Gemstone);
        });


        //银币按钮
        self.UI_Head.UI_SilverCoin.Button.ButtonShrink(() =>
        {

        });

        //宝石按钮
        self.UI_Head.UI_Gemstone.Button.ButtonShrink(() =>
        {

        });

        //设置按钮
        self.UI_Head.UI_OptionButton.Button.ButtonShrink(() =>
        {

        });

        //开始游戏按钮
        self.UI_PlayGameButton.Button.ButtonShrink(() =>
        {
            GameUIModel.CreateAnsy<GameUIModel>();
        });
    }
}
