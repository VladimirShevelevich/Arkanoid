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
        private readonly IWinCondition _winCondition;
        public event Action<Type> SetState;
        
        public GameplayState(IDeadZoneService deadZoneService, IWinCondition winCondition)
        {
            _deadZoneService = deadZoneService;
            _winCondition = winCondition;
        }

        public void Init()
        {
            _deadZoneService.OnDeadTriggered += OnDeadZoneTriggered;
            _winCondition.OnWin += OnWin;
        }

        private void OnDeadZoneTriggered()
        {
            SetState?.Invoke(typeof(GameOverState));            
        }

        private void OnWin()
        {
            SetState.Invoke(typeof(WinState));   
        }

        public void Dispose()
        {
            _deadZoneService.OnDeadTriggered -= OnDeadZoneTriggered;
            _winCondition.OnWin -= OnWin;
        }
    }
}