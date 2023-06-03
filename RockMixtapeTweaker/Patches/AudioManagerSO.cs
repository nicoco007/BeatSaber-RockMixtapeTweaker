#if DEBUG
using HarmonyLib;

namespace RockMixtapeTweaker.Patches;

[HarmonyPatch(typeof(AudioManagerSO), nameof(AudioManagerSO.musicVolume), MethodType.Setter)]
internal static class AudioManagerSO_musicVolume
{
    public static void Postfix(float value)
    {
        Plugin.log.Info("Music volume set to: " + value);
    }
}
#endif // DEBUG
