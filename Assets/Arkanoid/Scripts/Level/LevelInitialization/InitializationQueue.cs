using System;
using System.Collections.Generic;
using Arkanoid.Ball;
using Arkanoid.Bricks;
using Arkanoid.Platform;
using Cysharp.Threading.Tasks;
using UniRx;
using VContainer.Unity;

namespace Arkanoid.LevelInitialization
{
    public class InitializationQueue : IInitializable
    {
        public IObservable<Unit> OnInitializationCompleted => _onInitializationCompleted;
        private readonly ReactiveCommand _onInitializationCompleted = new();
        
        private readonly IBricksService _brickService;
        private readonly IPlatformService _platformService;
        private readonly BallService _ballService;

        public InitializationQueue(IBricksService brickService, 
            IPlatformService platformService, 
            BallService ballService)
        {
            _brickService = brickService;
            _platformService = platformService;
            _ballService = ballService;
        }
        
        public void Initialize()
        {
            InitializeAsync().Forget();
        }

        private async UniTask InitializeAsync()
        {
            //initialization order depended services
            var parallelInitializables = new List<UniTask>
            {
                _brickService.InitializeAsync(),
                _platformService.InitializeAsync()
            };

            await UniTask.WhenAll(parallelInitializables);
            
            _ballService.Initialize();
            _onInitializationCompleted?.Execute();
        }
    }
}