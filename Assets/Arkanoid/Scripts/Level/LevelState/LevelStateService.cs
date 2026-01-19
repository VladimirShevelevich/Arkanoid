using System;
using Arkanoid.LevelState.States;
using UniRx;
using VContainer;
using VContainer.Unity;

namespace Arkanoid.LevelState
{
    /// <summary>
    /// managing "win" and "game over" states of the game
    /// </summary>
    public class LevelStateService : ILevelStateService
    {
        public IReadOnlyReactiveProperty<Type> CurrentState => _currentStateProperty;
        private readonly ReactiveProperty<Type> _currentStateProperty = new();

        
        private readonly IObjectResolver _objectResolver;
        private ILevelState _currentState;

        public LevelStateService(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }
        
        public void Initialize()
        {
            SetInitialState();
        }


        private void SetInitialState()
        {
            SetState(typeof(LoadingState));
        }

        private void SetState(Type stateType)
        {
            _currentState?.Dispose();
            _currentState = _objectResolver.Resolve(stateType) as ILevelState;
            _currentState.SetState += SetState;
            _currentState.Init();
            
            _currentStateProperty.Value = stateType;
        }
   }
}