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

        private bool _secondChanceIsUsed;
        
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
            if (_secondChanceIsUsed)
                SetGameOverState();
            else
                SetSecondStateState();
        }

        private void SetGameOverState()
        {
            SetState?.Invoke(typeof(GameOverState));
        }

        private void SetSecondStateState()
        {
            _secondChanceIsUsed = true;
            SetState?.Invoke(typeof(SecondChanceState));    
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