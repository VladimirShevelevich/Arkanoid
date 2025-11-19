using Arkanoid.Platform;
using UnityEngine;

namespace Arkanoid.Ball
{
    public class BallFactory
    {
        private readonly BallContent _ballContent;
        private readonly IPlatformService _platformService;

        public BallFactory(BallContent ballContent, IPlatformService platformService)
        {
            _ballContent = ballContent;
            _platformService = platformService;
        }
        
        public void Create()
        {
            GameObject go = Object.Instantiate(_ballContent.BallPrefab);
            go.transform.parent = _platformService.PlatformTransform;
        }
    }
}