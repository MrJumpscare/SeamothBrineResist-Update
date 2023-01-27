using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using System.IO;
using SeamothBrineResist.Modules;

namespace BrineUpdate
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class BrineUpdate_SN : BaseUnityPlugin
    {
        private const string myGUID = "mrjumpscare.brineupdate.nl";
        private const string pluginName = "Brine Resist Update";
        private const string versionString = "1.0.0";

        private static Assembly myAssembly = Assembly.GetExecutingAssembly();
        private static string ModPath = Path.GetDirectoryName(myAssembly.Location);
        internal static string AssetsFolder = Path.Combine(ModPath, "Assets");

        private static readonly Harmony harmony = new Harmony(myGUID);

        public static ManualLogSource logger;

        private void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "loaded.");
            logger = Logger;
            BrineUpdate_SN.harmony.PatchAll();
            SeamothBrineResistanceModule seamothBrineResistanceModule = new SeamothBrineResistanceModule();
            seamothBrineResistanceModule.Patch();
        }
    }
}
