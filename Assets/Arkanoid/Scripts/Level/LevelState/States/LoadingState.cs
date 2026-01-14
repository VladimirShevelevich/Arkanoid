using System;
using Arkanoid.LevelInitialization;
using Arkanoid.Tools.Disposable;
using UniRx;

namespace Arkanoid.LevelState.States
{
    public class LoadingState : BaseDisposable, ILevelState
    {
        private readonly InitializationQueue _initializationQueue;
        public event Action<Type> SetState;

        public LoadingState(InitializationQueue initializationQueue)
        {
            _initializationQueue = initializationQueue;
        }
        
        public void Init()
        {
            AddDisposable(
                _initializationQueue.OnInitializationCompleted.Subscribe(_ => OnInitializationCompleted()));
        }

        private void OnInitializationCompleted()
        {
            SetState.Invoke(typeof(GameplayState));
        }
    }
}