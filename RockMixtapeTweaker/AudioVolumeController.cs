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
            _audioManager.musicVolume = _perceivedLoudnessPerLevelModel.GetLoudnessCorrectionByLevelId(level.levelID);
        }
    }
}
