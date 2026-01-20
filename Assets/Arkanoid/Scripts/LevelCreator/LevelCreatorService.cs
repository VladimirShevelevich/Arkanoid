using VContainer;
using VContainer.Unity;

namespace Arkanoid.Level
{
    public class LevelCreatorService : IInitializable, ILevelCreatorService
    {
        private readonly LifetimeScope _gameScope;
        private readonly LevelsContent _levelsContent;
        private LifetimeScope _levelScope;
        private int _currentLevelIndex;

        public LevelCreatorService(LifetimeScope gameScope, LevelsContent levelsContent)
        {
            _gameScope = gameScope;
            _levelsContent = levelsContent;
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
            LevelConfig levelConfig = _levelsContent.Levels[_currentLevelIndex % _levelsContent.Levels.Length];
            _levelScope = _gameScope.CreateChildFromPrefab(_levelsContent.LevelScopePrefab, builder =>
            {
                builder.RegisterInstance(levelConfig);
            });
        }
    }
}