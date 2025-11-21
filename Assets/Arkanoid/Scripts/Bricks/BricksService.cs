using System;
using Arkanoid.Level;
using VContainer.Unity;

namespace Arkanoid.Bricks
{
    public class BricksService : IInitializable, IBricksService
    {
        public event Action OnBrickDestroyed;
        
        private readonly BricksFactory _bricksFactory;
        private readonly LevelConfig _levelConfig;

        public BricksService(BricksFactory bricksFactory, LevelConfig levelConfig)
        {
            _bricksFactory = bricksFactory;
            _levelConfig = levelConfig;
        }
        
        public void Initialize()
        {
            SpawnBricks();
        }

        private void SpawnBricks()
        {
            foreach (var brickInfo in _levelConfig.Bricks)   
            {
                IBrick brick = _bricksFactory.Create(brickInfo);
                brick.OnDestroyed += () => OnBrickDestroyed?.Invoke();
            }
        }
    }
}