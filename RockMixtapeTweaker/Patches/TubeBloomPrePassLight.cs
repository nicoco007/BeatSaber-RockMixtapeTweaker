using HarmonyLib;
using IPA.Utilities;

namespace RockMixtapeTweaker.Patches;

[HarmonyPatch(typeof(TubeBloomPrePassLight), "OnEnable")]
internal static class TubeBloomPrePassLight_OnEnable
{
    private static readonly FieldAccessor<TubeBloomPrePassLight, float>.Accessor kColorAlphaMultiplierAccessor = FieldAccessor<TubeBloomPrePassLight, float>.GetAccessor("_colorAlphaMultiplier");

    public static void Prefix(TubeBloomPrePassLight __instance)
    {
        if (__instance.name == "GuitarFret")
        {
            SetValues(__instance, 2f, 1);
        }

        if (__instance.transform.parent != null && __instance.transform.parent.name == "GuitarStringLaser")
        {
            SetValues(__instance, 0.1f, 1);
        }
    }

    private static void SetValues(TubeBloomPrePassLight light, float bloomFogIntensityMultiplier, float colorAlphaMultiplier)
    {
        float intensity = Plugin.settings.guitarLightingIntensity;

        if (intensity <= 0)
        {
            light.gameObject.SetActive(false);
            return;
        }

        light.bloomFogIntensityMultiplier = bloomFogIntensityMultiplier * intensity;
        kColorAlphaMultiplierAccessor(ref light) = colorAlphaMultiplier * intensity;
        light.MarkDirty();
    }
}
