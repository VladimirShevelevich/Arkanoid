using Arkanoid.DeadZone;
using Arkanoid.Popups;
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
        private readonly IPopupsService _popupsService;

        public LevelStateService(IDeadZoneService deadZoneService, IPopupsService popupsService)
        {
            _deadZoneService = deadZoneService;
            _popupsService = popupsService;
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
            _popupsService.ShopPopup<GameOverPopupFactory>();
        }
        
        private void SetWinState()
        {
            
        }
    }
}