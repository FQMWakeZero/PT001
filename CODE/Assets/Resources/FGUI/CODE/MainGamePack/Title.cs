/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainGamePack
{
    public partial class Title : GComponent
    {
        public GImage n4;
        public GTextField n5;
        public const string URL = "ui://miewpp62jbpe2";

        public static Title CreateInstance()
        {
            return (Title)UIPackage.CreateObject("MainGamePack", "Title");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            n5 = (GTextField)GetChildAt(1);
        }
    }
}