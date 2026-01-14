using UnityEngine;
using VContainer;

namespace Arkanoid.DeadZone
{
    public class DeadZoneFactory
    {
        private readonly DeadZoneContent _deadZoneContent;
        private readonly IObjectResolver _objectResolver;

        public DeadZoneFactory(DeadZoneContent deadZoneContent, IObjectResolver objectResolver)
        {
            _deadZoneContent = deadZoneContent;
            _objectResolver = objectResolver;
        }
        
        public DeadZoneView Create()
        {
            var view = Object.Instantiate(_deadZoneContent.DeadZonePrefab);
            _objectResolver.Inject(view);
            return view;
        }
    }
}