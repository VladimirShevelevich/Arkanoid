using Arkanoid.DeadZone;
using UniRx;
using VContainer.Unity;

namespace Arkanoid.LevelState
{
    /// <summary>
    /// managing "win" and "game over" states of the game
    /// </summary>
    public class LevelStateService : IInitializable, ILevelStateService
    {
        public IReadOnlyReactiveProperty<LevelStateType> CurrentState => _currentState;
        private readonly ReactiveProperty<LevelStateType> _currentState = new();
        
        private readonly IDeadZoneService _deadZoneService;

        public LevelStateService(IDeadZoneService deadZoneService)
        {
            _deadZoneService = deadZoneService;
        }
        
        public void Initialize()
        {
            _deadZoneService.OnDeadTriggered += SetGameOverState;
            SetGamePlayState();
        }

        private void SetGamePlayState()
        {
            _currentState.Value = LevelStateType.GamePlay;
        }

        private void SetGameOverState()
        {
            _currentState.Value = LevelStateType.GameOver;
        }
        
        private void SetWinState()
        {
            
        }
    }
}