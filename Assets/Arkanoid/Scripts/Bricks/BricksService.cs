using Arkanoid.Level;
using VContainer.Unity;

namespace Arkanoid.Bricks
{
    public class BricksService : IInitializable
    {
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
            foreach (var brickGridPos in _levelConfig.BricksGridPositions)
            {
                _bricksFactory.Create(brickGridPos);
            }
        }
    }
}