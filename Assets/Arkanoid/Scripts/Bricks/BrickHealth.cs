using System;

namespace Arkanoid.Bricks
{
    public class BrickHealth
    {
        public event Action OnDestroyed;
        
        private readonly BrickView _view;
        private int _currentHealth;

        public BrickHealth(int health, BrickView view)
        {
            _currentHealth = health;
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
    }
}