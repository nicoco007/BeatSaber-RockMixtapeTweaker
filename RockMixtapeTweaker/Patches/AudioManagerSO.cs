#if DEBUG
using HarmonyLib;
using UnityEngine;

namespace RockMixtapeTweaker.Patches;

/// <summary>
/// Patches <see cref="SongPreviewPlayer.CrossfadeTo"/> so it doesn't set <see cref="AudioManagerSO.musicVolume"/> if crossfading to the default audio clip.
/// This prevents <see cref="SongPreviewPlayer"/> from overriding the song's volume via <see cref="LevelCollectionViewController.DidDeactivate(bool, bool)"/>.
/// </summary>
[HarmonyPatch(typeof(AudioManagerSO), nameof(AudioManagerSO.musicVolume), MethodType.Setter)]
internal static class AudioManagerSO_musicVolume
{
    public static void Postfix(float value)
    {
        Debug.Log("Music volume set to: " + value);
    }
}
#endif // DEBUG
