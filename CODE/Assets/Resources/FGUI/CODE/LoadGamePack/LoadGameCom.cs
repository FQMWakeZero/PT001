/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace LoadGamePack
{
    public partial class LoadGameCom : GComponent
    {
        public GImage n1;
        public LoadGameBar LogingBar;
        public Transition End;
        public const string URL = "ui://mx6k5pl6gd7s0";

        public static LoadGameCom CreateInstance()
        {
            return (LoadGameCom)UIPackage.CreateObject("LoadGamePack", "LoadGameCom");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            LogingBar = (LoadGameBar)GetChildAt(1);
            End = GetTransitionAt(0);
        }
    }
}