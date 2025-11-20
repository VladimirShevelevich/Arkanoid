using Arkanoid.DeadZone;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Arkanoid.LevelState
{
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
        }

        private void SetGameOverState()
        {
            Debug.Log("GameOver");
        }
        
        private void SetWinState()
        {
            
        }
    }
}