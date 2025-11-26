using System;
using Arkanoid.Bricks;
using Arkanoid.Level;

namespace Arkanoid.LevelState.States
{
    public class BricksOverWinCondition : IWinCondition
    {
        public event Action OnWin;
        
        private readonly IBricksService _bricksService;
        private readonly LevelConfig _levelConfig;
        
        private int _bricksLeft;

        public BricksOverWinCondition(IBricksService bricksService, LevelConfig levelConfig)
        {
            _bricksService = bricksService;
            _levelConfig = levelConfig;
            _bricksLeft = _levelConfig.Bricks.Length;
            
            _bricksService.OnBrickDestroyed += OnBrickDestroyed;
        }

        private void OnBrickDestroyed()
        {
            _bricksLeft--;
            if (_bricksLeft <= 0)
            {
                OnBricksOver();
            }
        }

        private void OnBricksOver()
        {
            OnWin?.Invoke();
        }

        public void Dispose()
        {
            _bricksService.OnBrickDestroyed -= OnBrickDestroyed;
        }
    }
}