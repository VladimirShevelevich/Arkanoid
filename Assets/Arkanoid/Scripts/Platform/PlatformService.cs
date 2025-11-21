using Arkanoid.Tools.Disposable;
using UnityEngine;
using VContainer.Unity;

namespace Arkanoid.Platform
{
    public class PlatformService : BaseDisposable, IInitializable, IPlatformService
    {
        private readonly PlatformFactory _platformFactory;
        private GameObject _view;

        public Transform PlatformTransform => _view.transform;

        public PlatformService(PlatformFactory platformFactory)
        {
            _platformFactory = platformFactory;
        }

        public void Initialize()
        {
            _view = _platformFactory.Create();
            AddDisposable(new GameObjectDisposer(_view.gameObject));
        }
    }
}