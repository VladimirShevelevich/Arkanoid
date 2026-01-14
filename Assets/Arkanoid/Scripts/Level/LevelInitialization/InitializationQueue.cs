using System.Collections.Generic;
using Arkanoid.Ball;
using Arkanoid.Bricks;
using Arkanoid.LevelState;
using Arkanoid.Platform;
using Arkanoid.Tools.Initialization;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Arkanoid.LevelInitialization
{
    public class InitializationQueue : IInitializable
    {
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
            var asyncInitializables = new List<UniTask>
            {
                _brickService.InitializeAsync(),
                _platformService.InitializeAsync()
            };

            await UniTask.WhenAll(asyncInitializables);
            
            _ballService.Initialize();
        }
    }
}