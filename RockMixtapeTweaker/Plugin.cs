using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Logging;
using SiraUtil.Zenject;
using Zenject;

namespace RockMixtapeTweaker;

[Plugin(RuntimeOptions.DynamicInit)]
public class Plugin
{
    internal static Settings settings = null!;

    private readonly Harmony _harmony = new("com.nicoco007.rock-mixtape-improver");
    private readonly Logger _logger;

    [Init]
    public Plugin(Config config, Logger logger, Zenjector zenjector)
    {
        settings = config.Generated<Settings>();
        _logger = logger;

        zenjector.Install<GameplayCoreInstaller>(container =>
        {
            container.Bind(typeof(IInitializable)).To<AudioVolumeController>().AsSingle().NonLazy();
        });
    }

    [OnEnable]
    public void OnEnable()
    {
        _logger.Info($"{nameof(RockMixtapeTweaker)} enabled.");
        _harmony.PatchAll();
    }

    [OnDisable]
    public void OnDisable()
    {
        _harmony.UnpatchSelf();
        _logger.Info($"{nameof(RockMixtapeTweaker)} disabled.");
    }
}
