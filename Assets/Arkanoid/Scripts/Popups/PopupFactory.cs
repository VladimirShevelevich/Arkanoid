using UnityEngine;

namespace Arkanoid.Popups
{
    public abstract class PopupFactory
    {
        private readonly Canvas _mainCanvas;

        protected PopupFactory(Canvas mainCanvas)
        {
            _mainCanvas = mainCanvas;
        }
        
        public abstract IPopup Create(object context);

        protected T InstantiateView<T>(T viewPrefab) where T : MonoBehaviour
        {
            return Object.Instantiate(viewPrefab, _mainCanvas.transform);
        }
    }
}