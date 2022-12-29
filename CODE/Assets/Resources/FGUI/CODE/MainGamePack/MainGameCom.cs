/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainGamePack
{
    public partial class MainGameCom : GComponent
    {
        public GImage n0;
        public GGraph Eff_1;
        public Title n3;
        public Transition Play;
        public const string URL = "ui://miewpp62jbpe0";

        public static MainGameCom CreateInstance()
        {
            return (MainGameCom)UIPackage.CreateObject("MainGamePack", "MainGameCom");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            Eff_1 = (GGraph)GetChildAt(1);
            n3 = (Title)GetChildAt(2);
            Play = GetTransitionAt(0);
        }
    }
}