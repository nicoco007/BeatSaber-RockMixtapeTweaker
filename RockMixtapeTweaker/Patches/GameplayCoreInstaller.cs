using HarmonyLib;
using IPA.Utilities;
using Zenject;

namespace RockMixtapeTweaker.Patches
{
    [HarmonyPatch(typeof(GameplayCoreInstaller), nameof(GameplayCoreInstaller.InstallBindings))]
    internal class GameplayCoreInstaller_InstallBindings
    {
        public static void Postfix(GameplayCoreInstaller __instance, AudioManagerSO ____audioManager)
        {
            __instance.GetProperty<DiContainer, MonoInstallerBase>("Container").Bind<AudioManagerSO>().FromInstance(____audioManager).IfNotBound();
        }
    }
}
