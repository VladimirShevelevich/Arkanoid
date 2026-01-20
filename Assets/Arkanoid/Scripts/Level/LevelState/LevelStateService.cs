using System;
using Arkanoid.LevelState.SecondChance;
using Arkanoid.LevelState.States;
using Arkanoid.Popups;
using Arkanoid.Tools.Disposable;
using UniRx;
using VContainer;

namespace Arkanoid.LevelState
{
    /// <summary>
    /// managing "win" and "game over" states of the game
    /// </summary>
    public class LevelStateService : BaseDisposable, ILevelStateService
    {
        public IReadOnlyReactiveProperty<Type> CurrentState => _currentStateProperty;
        private readonly ReactiveProperty<Type> _currentStateProperty = new();


        private readonly PopupAbstractFactory _popupAbstractFactory;
        private readonly IObjectResolver _objectResolver;
        private ILevelState _currentState;

        public LevelStateService(PopupAbstractFactory popupAbstractFactory, IObjectResolver objectResolver)
        {
            _popupAbstractFactory = popupAbstractFactory;
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
            AddDisposable(_currentState);
            _currentState.SetState += SetState;
            _currentState.Init();
            
            _currentStateProperty.Value = stateType;
        }
   }
}