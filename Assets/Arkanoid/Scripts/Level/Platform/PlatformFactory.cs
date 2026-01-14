using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Arkanoid.Platform
{
    public class PlatformFactory
    {
        private readonly PlatformContent _platformContent;
        private readonly IObjectResolver _objectResolver;

        public PlatformFactory(PlatformContent platformContent, IObjectResolver objectResolver)
        {
            _platformContent = platformContent;
            _objectResolver = objectResolver;
        }
        
        public GameObject Create()
        {
            GameObject go = Object.Instantiate(_platformContent.PlatformPrefab);
            _objectResolver.InjectGameObject(go);
            return go;
        }
    }
}