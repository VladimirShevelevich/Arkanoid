using System;
using Arkanoid.Tools;

namespace Arkanoid.Bricks
{
    public class BrickHealth : IDisposable
    {
        public event Action OnDestroyed;
        
        private readonly BrickView _view;
        private int _currentHealth;

        public BrickHealth(int startHealth, BrickView view)
        {
            if (startHealth <= 0)
            {
                CustomLogger.LogError("Brick's starting health must be more than zero");
                return;
            }
            
            _currentHealth = startHealth;
            _view = view;
        }

        public void Init()
        {
            _view.UpdateViewByHealth(_currentHealth);
            _view.OnHit += OnBrickHit;
        }

        private void OnBrickHit()
        {
            _currentHealth--;
            if (_currentHealth <= 0)
            {
                _view.PlayDestroyVfx();
                OnDestroyed?.Invoke();
            }
            else
            {
                _view.UpdateViewByHealth(_currentHealth);
            }
        }


        public void Dispose()
        {
            _view.OnHit -= OnBrickHit;
        }
    }
}