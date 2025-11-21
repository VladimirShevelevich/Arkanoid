using System;
using Arkanoid.Level;
using Arkanoid.Tools.Disposable;
using UnityEngine;
using VContainer.Unity;

namespace Arkanoid.Bricks
{
    public class BricksService : BaseDisposable, IInitializable, IBricksService
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
            GameObject parent = new GameObject("Bricks");
            AddDisposable(new GameObjectDisposer(parent));
            
            foreach (var brickInfo in _levelConfig.Bricks)   
            {
                IBrick brick = _bricksFactory.Create(brickInfo, parent.transform);
                AddDisposable(brick);
                brick.OnDestroyed += () => OnBrickDestroyed?.Invoke();
            }
        }
    }
}