using FairyGUI;
using LoadGamePack;
using MainGamePack;

namespace ECSFrame
{
    public class ResourcesManager
    {
        public static void Load()
        {
            UIPackage.AddPackage("FGUI/FUI/LoadGamePack");
            LoadGamePackBinder.BindAll();

            UIPackage.AddPackage("FGUI/FUI/MainGamePack");
            MainGamePackBinder.BindAll();

            UIPackage.AddPackage("FGUI/FUI/Form");
        }
    }
}
