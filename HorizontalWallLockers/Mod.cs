using BepInEx;
using Logger = AlexejheroYTB.Common.Logger;
namespace AlexejheroYTB.HorizontalWallLockers.main
{
    [BepInPlugin(QMod.PLUGIN_GUID, QMod.PLUGIN_NAME, QMod.PLUGIN_VERSION)]
    public  class QMod : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "SN.HorizontalWallLockers";

        // Token: 0x04000007 RID: 7
        public const string PLUGIN_NAME = "SN.HorizontalWallLockers";

        // Token: 0x04000008 RID: 8
        public const string PLUGIN_VERSION = "1.0.0";
        public void Awake()
        {
            prefab.HorizontalWallLockers.Patch();

            Logger.LogInfo("Patched");
        }
    }

   
    
}
