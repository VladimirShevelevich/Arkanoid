using Arkanoid.Platform;
using Arkanoid.Tools.Extensions;
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
        
        public GameObject Create()
        {
            var go = Object.Instantiate(_ballContent.BallPrefab);
            var platformPosition = _platformService.PlatformTransform.position;
            var initialPosition = go.transform.position.WithX(platformPosition.x);
            go.transform.position = initialPosition;
            _objectResolver.InjectGameObject(go);
            return go;
        }
    }
}