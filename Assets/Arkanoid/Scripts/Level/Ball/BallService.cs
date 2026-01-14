using Arkanoid.LevelState;
using Arkanoid.LevelState.States;
using Arkanoid.Tools.Disposable;
using UniRx;
using UnityEngine;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Arkanoid.Ball
{
    public class BallService : BaseDisposable, IInitializable
    {
        private readonly BallFactory _ballFactory;
        private readonly ILevelStateService _levelStateService;

        private GameObject _ballGo;

        public BallService(BallFactory ballFactory, ILevelStateService levelStateService)
        {
            _ballFactory = ballFactory;
            _levelStateService = levelStateService;
        }

        public void Initialize()
        {
            AddDisposable(_levelStateService.CurrentState.Subscribe(type =>
            {
                if (type == typeof(GameplayState))
                    OnGameplayStateSet();
                else 
                    OnGameplayStateOver();
            }));
        }

        private void OnGameplayStateSet()
        {
            CreateBall();
        }

        private void OnGameplayStateOver()
        {
            DestroyBall();
        }

        private void DestroyBall()
        {
            if (_ballGo != null)
                Object.Destroy(_ballGo);
        }

        private void CreateBall()
        {
            _ballGo = _ballFactory.Create();
            AddDisposable(new GameObjectDisposer(_ballGo));
        }
    }
}