using System;

namespace Arkanoid.Bricks
{
    /// <summary>
    /// Facade used by BricksService
    /// </summary>
    public class Brick : IBrick
    {
        public event Action OnDestroyed;
        
        private readonly BrickHealth _health;
        private readonly BrickView _view;

        public Brick(BrickHealth health, BrickView view)
        {
            _health = health;
            _view = view;

            _health.OnDestroyed += () => OnDestroyed?.Invoke();
        }
    }
}