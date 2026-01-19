using Arkanoid.Tools.Disposable;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Arkanoid.Platform
{
    public class PlatformService : BaseDisposable, IPlatformService
    {
        private readonly PlatformFactory _platformFactory;
        private GameObject _view;

        public Transform PlatformTransform => _view.transform;

        public PlatformService(PlatformFactory platformFactory)
        {
            _platformFactory = platformFactory;
        }

        public async UniTask InitializeAsync()
        {
            //simulate async loading
            await UniTask.Delay(1000);
            
            _view = _platformFactory.Create();
            AddDisposable(new GameObjectDisposer(_view.gameObject));
        }
    }
}