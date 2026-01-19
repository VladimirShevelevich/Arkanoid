using System;
using Arkanoid.Level;
using Arkanoid.Tools.Disposable;

namespace Arkanoid.Bricks
{
    /// <summary>
    /// Facade used by BricksService
    /// </summary>
    public class Brick : BaseDisposable, IBrick
    {
        public event Action<LevelConfig.BrickInfo> OnDestroyed;
        
        private readonly BrickHealth _health;
        private readonly LevelConfig.BrickInfo _brickInfo;
        private readonly BrickView _view;

        public Brick(BrickHealth health, LevelConfig.BrickInfo brickInfo, BrickView view)
        {
            _health = health;
            _brickInfo = brickInfo;
            _view = view;

            _health.OnDestroyed += () => OnDestroyed?.Invoke(_brickInfo);
            
            AddDisposable(_health);
            AddDisposable(new GameObjectDisposer(_view.gameObject));
        }

        public override void Dispose()
        {
            base.Dispose();
            _health.OnDestroyed -= () => OnDestroyed?.Invoke(_brickInfo);
        }
    }
}