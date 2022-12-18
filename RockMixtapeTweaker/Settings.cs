using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(IPA.Config.Stores.GeneratedStore.AssemblyVisibilityTarget)]

namespace RockMixtapeTweaker;

internal class Settings
{
    public virtual float guitarLightingIntensity { get; set; } = 0.2f;
}
