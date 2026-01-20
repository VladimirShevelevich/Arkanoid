using System.Collections.Generic;
using Arkanoid.Tools.Disposable;

namespace Arkanoid.Popups
{
    public class PopupsService : BaseDisposable, IPopupsService
    {
        private readonly PopupAbstractFactory _popupAbstractFactory;
        private KeyValuePair<PopupType, IPopup> _openedPopup;
        
        public PopupsService(PopupAbstractFactory popupAbstractFactory)
        {
            _popupAbstractFactory = popupAbstractFactory;
        }
        
        public T ShowPopup<T>(PopupType popupType) where T : IPopup
        {
            var popup = _popupAbstractFactory.CreatePopup(popupType);
            AddDisposable(popup);
            _openedPopup = new KeyValuePair<PopupType, IPopup>(popupType, popup);
            return (T)popup;
        }

        public void HidePopup(PopupType popupType)
        {
            if (_openedPopup.Key != popupType)
                return;
            
            _openedPopup.Value.Dispose();
            _openedPopup = default;
        }
    }
}