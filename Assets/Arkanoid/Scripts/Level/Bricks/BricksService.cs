using System;
using Arkanoid.Level;
using Arkanoid.Tools.Disposable;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Arkanoid.Bricks
{
    public class BricksService : BaseDisposable, IBricksService
    {
        public event Action<LevelConfig.BrickInfo> OnBrickDestroyed;
        
        private readonly BricksFactory _bricksFactory;
        private readonly LevelConfig _levelConfig;

        public BricksService(BricksFactory bricksFactory, LevelConfig levelConfig)
        {
            _bricksFactory = bricksFactory;
            _levelConfig = levelConfig;
        }
        
        public async UniTask InitializeAsync()
        {
            await SpawnBricksAsync();
        }

        private async UniTask SpawnBricksAsync()
        {
            //simulate async loading
            await UniTask.Delay(2000);
            
            GameObject parent = new GameObject("Bricks");
            AddDisposable(new GameObjectDisposer(parent));
            
            foreach (var brickInfo in _levelConfig.Bricks)   
            {
                IBrick brick = _bricksFactory.Create(brickInfo, parent.transform);
                AddDisposable(brick);
                brick.OnDestroyed += brickInfo => OnBrickDestroyed?.Invoke(brickInfo);
            }
        }
    }
}