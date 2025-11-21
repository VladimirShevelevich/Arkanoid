using System;
using Arkanoid.Tools.Disposable;

namespace Arkanoid.Bricks
{
    /// <summary>
    /// Facade used by BricksService
    /// </summary>
    public class Brick : BaseDisposable, IBrick
    {
        public event Action OnDestroyed;
        
        private readonly BrickHealth _health;
        private readonly BrickView _view;

        public Brick(BrickHealth health, BrickView view)
        {
            _health = health;
            _view = view;

            _health.OnDestroyed += () => OnDestroyed?.Invoke();
            
            AddDisposable(_health);
            AddDisposable(new GameObjectDisposer(_view.gameObject));
        }

        public override void Dispose()
        {
            base.Dispose();
            _health.OnDestroyed -= () => OnDestroyed?.Invoke();
        }
    }
}