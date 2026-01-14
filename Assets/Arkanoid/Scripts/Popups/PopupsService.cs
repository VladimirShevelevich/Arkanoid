using System;
using System.Collections.Generic;
using Arkanoid.Tools.Disposable;
using VContainer;

namespace Arkanoid.Popups
{
    public class PopupsService : BaseDisposable, IPopupsService
    {
        private readonly IObjectResolver _objectResolver;

        private KeyValuePair<Type, IPopup> _openedPopup;
        
        public PopupsService(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }
        
        public void ShowPopup<TFactory>(object context) where TFactory : PopupsFactory
        {
            TFactory factory = _objectResolver.Resolve<TFactory>();
            var popup = factory.Create(context);
            AddDisposable(popup);
            _openedPopup = new KeyValuePair<Type, IPopup>(typeof(TFactory), popup);
        }

        public void HidePopup<TFactory>() where TFactory : PopupsFactory
        {
            if (_openedPopup.Key != typeof(TFactory)) 
                return;
            
            var popup = _openedPopup.Value;
            popup.Dispose();
            _openedPopup = default;
        }
    }
}