using VContainer;
using VContainer.Unity;

namespace Arkanoid.Level
{
    public class LevelCreatorService : IInitializable, ILevelCreatorService
    {
        private readonly LifetimeScope _gameScope;
        private readonly LevelConfig[] _levels;
        private LevelScope _levelScope;
        private int _currentLevelIndex;

        public LevelCreatorService(LifetimeScope gameScope, LevelsContent levelsContent)
        {
            _gameScope = gameScope;
            _levels = levelsContent.Levels;
        }
        
        public void Initialize()
        {
            CreateLevelByCurrentIndex();   
        }

        public void ReloadLevel()
        {
            CreateLevelByCurrentIndex();
        }

        public void LoadNextLevel()
        {
            _currentLevelIndex++;
            CreateLevelByCurrentIndex();
        }
        
        private void CreateLevelByCurrentIndex()
        {
            _levelScope?.Dispose();
            LevelConfig levelConfig = _levels[_currentLevelIndex % _levels.Length];
            _levelScope = _gameScope.CreateChild<LevelScope>(builder =>
            {
                builder.RegisterInstance(levelConfig);
            });
        }
    }
}