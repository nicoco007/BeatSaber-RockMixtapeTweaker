using Zenject;

namespace RockMixtapeTweaker
{
    internal class AudioVolumeController : IInitializable
    {
        [Inject]
        private readonly GameplayCoreSceneSetupData _gameplayCoreSceneSetupData = null!;

        [Inject]
        private readonly PerceivedLoudnessPerLevelModel _perceivedLoudnessPerLevelModel = null!;

        [Inject]
        private readonly AudioManagerSO _audioManager = null!;

        public void Initialize()
        {
            IBeatmapLevel level = _gameplayCoreSceneSetupData.difficultyBeatmap.level;
            float volume = _perceivedLoudnessPerLevelModel.GetLoudnessCorrectionByLevelId(level.levelID);
            Plugin.log.Notice($"Overriding volume: set to {volume}");
            _audioManager.musicVolume = volume;
        }
    }
}
