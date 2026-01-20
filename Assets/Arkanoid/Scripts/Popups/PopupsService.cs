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
        
        public void ShowPopup(PopupType popupType, object context)
        {
            var popup = _popupAbstractFactory.CreatePopup(popupType, context);
            AddDisposable(popup);
            _openedPopup = new KeyValuePair<PopupType, IPopup>(popupType, popup);
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