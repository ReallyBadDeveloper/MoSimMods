using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace InfiniteRounds
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;

        private void Awake()
        {
            // Plugin startup logic
            Logger = base.Logger;
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
            Harmony harmony = new(MyPluginInfo.PLUGIN_GUID);
            harmony.PatchAll(typeof(Patches));
        }
    }
    public class Patches
    {
        [HarmonyPatch(typeof(GameManager), nameof(GameManager.Update))]
        [HarmonyPostfix]
        public static void Update(GameManager __instance)
        {
            // Plugin.Logger.LogInfo(__instance.timer.ToString());
            __instance.timer = 150f;
            __instance.timerText.text = "∞";
        }
    }
}
