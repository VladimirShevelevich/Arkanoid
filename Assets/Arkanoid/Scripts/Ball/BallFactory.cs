using Arkanoid.Platform;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Arkanoid.Ball
{
    public class BallFactory
    {
        private readonly BallContent _ballContent;
        private readonly IPlatformService _platformService;
        private readonly IObjectResolver _objectResolver;

        public BallFactory(BallContent ballContent, IPlatformService platformService, IObjectResolver objectResolver)
        {
            _ballContent = ballContent;
            _platformService = platformService;
            _objectResolver = objectResolver;
        }
        
        public void Create()
        {
            GameObject go = Object.Instantiate(_ballContent.BallPrefab);
            _objectResolver.InjectGameObject(go);
            go.transform.parent = _platformService.PlatformTransform;
        }
    }
}