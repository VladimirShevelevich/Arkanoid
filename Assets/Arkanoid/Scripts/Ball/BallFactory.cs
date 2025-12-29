using Arkanoid.Platform;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Arkanoid.Ball
{
    public class BallFactory
    {
        private readonly BallContent _ballContent;
        private readonly IObjectResolver _objectResolver;

        public BallFactory(BallContent ballContent, IObjectResolver objectResolver)
        {
            _ballContent = ballContent;
            _objectResolver = objectResolver;
        }
        
        public GameObject Create()
        {
            GameObject go = Object.Instantiate(_ballContent.BallPrefab);
            _objectResolver.InjectGameObject(go);
            return go;
        }
    }
}