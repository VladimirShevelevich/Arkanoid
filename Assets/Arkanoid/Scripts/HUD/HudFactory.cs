using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Arkanoid.HUD
{
    public class HudFactory
    {
        private readonly HudContent _hudContent;
        private readonly Canvas _mainCanvas;
        private readonly IObjectResolver _objectResolver;

        public HudFactory(HudContent hudContent, Canvas mainCanvas, IObjectResolver objectResolver)
        {
            _hudContent = hudContent;
            _mainCanvas = mainCanvas;
            _objectResolver = objectResolver;
        }
        
        public GameObject Create()
        {
            var go = Object.Instantiate(_hudContent.HudPrefab, _mainCanvas.transform);
            _objectResolver.InjectGameObject(go);
            return go;
        }
    }
}