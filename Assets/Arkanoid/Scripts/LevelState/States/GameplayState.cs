using System;
using Arkanoid.DeadZone;

namespace Arkanoid.LevelState.States
{
    public class GameplayState : ILevelState
    {
        private readonly IDeadZoneService _deadZoneService;
        public event Action<Type> SetState;

        public GameplayState(IDeadZoneService deadZoneService)
        {
            _deadZoneService = deadZoneService;
        }

        public void Init()
        {
            _deadZoneService.OnDeadTriggered += OnDeadZoneTriggered;
        }

        private void OnDeadZoneTriggered()
        {
            SetState?.Invoke(typeof(GameOverState));            
        }

        public void Dispose()
        {
            _deadZoneService.OnDeadTriggered -= OnDeadZoneTriggered;
        }
    }
}