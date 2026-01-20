using UnityEngine;
using VContainer.Unity;

namespace Arkanoid.Popups
{
    public abstract class PopupFactory : IInitializable
    {
        public abstract PopupType PopupType { get; }
        protected readonly PopupAbstractFactory _popupAbstractFactory;

        private readonly Canvas _mainCanvas;

        protected PopupFactory(Canvas mainCanvas, PopupAbstractFactory popupAbstractFactory)
        {
            _mainCanvas = mainCanvas;
            _popupAbstractFactory = popupAbstractFactory;
        }

        public void Initialize()
        {
            _popupAbstractFactory.RegisterFactory(this);
        }

        public abstract IPopup Create();

        protected T InstantiateView<T>(T viewPrefab) where T : MonoBehaviour
        {
            return Object.Instantiate(viewPrefab, _mainCanvas.transform);
        }
    }
}