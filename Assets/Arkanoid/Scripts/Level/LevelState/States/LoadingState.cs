using System;
using Arkanoid.LevelInitialization;
using Arkanoid.LoadingScreen;
using Arkanoid.Tools.Disposable;
using UniRx;

namespace Arkanoid.LevelState.States
{
    public class LoadingState : BaseDisposable, ILevelState
    {
        private readonly InitializationQueue _initializationQueue;
        private readonly LoadingScreenService _loadingScreenService;
        public event Action<Type> SetState;

        public LoadingState(InitializationQueue initializationQueue, LoadingScreenService loadingScreenService)
        {
            _initializationQueue = initializationQueue;
            _loadingScreenService = loadingScreenService;
        }
        
        public void Init()
        {
            AddDisposable(
                _initializationQueue.OnInitializationCompleted.Subscribe(_ => OnInitializationCompleted()));
            
            _loadingScreenService.Show();
        }

        private void OnInitializationCompleted()
        {
            SetState.Invoke(typeof(GameplayState));
        }

        public override void Dispose()
        {
            base.Dispose();
            _loadingScreenService.Hide();
        }
    }
}