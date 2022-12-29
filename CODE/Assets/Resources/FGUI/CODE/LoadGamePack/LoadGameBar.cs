/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace LoadGamePack
{
    public partial class LoadGameBar : GProgressBar
    {
        public GImage n0;
        public GImage bar;
        public GTextField title;
        public const string URL = "ui://mx6k5pl6jbpe7";

        public static LoadGameBar CreateInstance()
        {
            return (LoadGameBar)UIPackage.CreateObject("LoadGamePack", "LoadGameBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
            title = (GTextField)GetChildAt(2);
        }
    }
}