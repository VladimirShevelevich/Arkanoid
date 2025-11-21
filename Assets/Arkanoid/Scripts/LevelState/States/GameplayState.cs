using System;
using Arkanoid.Bricks;
using Arkanoid.DeadZone;
using Arkanoid.Level;

namespace Arkanoid.LevelState.States
{
    public class GameplayState : ILevelState
    {
        private readonly IDeadZoneService _deadZoneService;
        private readonly IBricksService _bricksService;
        private readonly LevelConfig _levelConfig;
        public event Action<Type> SetState;

        private int _bricksLeft;
        
        public GameplayState(IDeadZoneService deadZoneService, IBricksService bricksService, LevelConfig levelConfig)
        {
            _deadZoneService = deadZoneService;
            _bricksService = bricksService;
            _levelConfig = levelConfig;
        }

        public void Init()
        {
            _deadZoneService.OnDeadTriggered += OnDeadZoneTriggered;
            _bricksService.OnBrickDestroyed += OnBrickDestroyed;
            _bricksLeft = _levelConfig.Bricks.Length;
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
            SetState?.Invoke(typeof(WinState));
        }

        private void OnDeadZoneTriggered()
        {
            SetState?.Invoke(typeof(GameOverState));            
        }

        public void Dispose()
        {
            _deadZoneService.OnDeadTriggered -= OnDeadZoneTriggered;
            _bricksService.OnBrickDestroyed -= OnBrickDestroyed;
        }
    }
}