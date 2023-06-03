using HarmonyLib;

namespace RockMixtapeTweaker.Patches
{
    [HarmonyPatch(typeof(GameplayCoreInstaller), nameof(GameplayCoreInstaller.InstallBindings))]
    internal class GameplayCoreInstaller_InstallBindings
    {
        public static void Postfix(GameplayCoreInstaller __instance)
        {
            __instance.Container.Bind<AudioManagerSO>().FromInstance(__instance._audioManager).IfNotBound();
        }
    }
}
