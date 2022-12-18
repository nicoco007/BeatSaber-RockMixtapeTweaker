using HarmonyLib;
using IPA.Utilities;

namespace RockMixtapeTweaker.Patches;

[HarmonyPatch(typeof(LightWithIdMonoBehaviour), "OnEnable")]
internal static class LightWithIdMonoBehaviour_OnEnable
{
    private static readonly FieldAccessor<SpriteLightWithId, float>.Accessor kIntensityAccessor = FieldAccessor<SpriteLightWithId, float>.GetAccessor("_intensity");

    public static void Prefix(LightWithIdMonoBehaviour __instance)
    {
        if (__instance is not SpriteLightWithId spriteLight || __instance.name != "GuitarDot")
        {
            return;
        }

        float intensity = Plugin.settings.guitarLightingIntensity;

        if (intensity <= 0)
        {
            __instance.gameObject.SetActive(false);
            return;
        }

        kIntensityAccessor(ref spriteLight) = intensity;
    }
}
