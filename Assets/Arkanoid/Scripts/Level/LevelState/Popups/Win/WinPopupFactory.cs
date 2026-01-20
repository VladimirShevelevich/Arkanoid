using Arkanoid.Popups;
using UnityEngine;
using VContainer;

namespace Arkanoid.LevelState
{
    public class WinPopupFactory : PopupFactory
    {
        public override PopupType PopupType => PopupType.Win;
        
        private readonly LevelStateContent _levelStateContent;
        private readonly IObjectResolver _objectResolver;


        public WinPopupFactory(LevelStateContent levelStateContent, IObjectResolver objectResolver, Canvas mainCanvas) : base(mainCanvas) 
        {
            _levelStateContent = levelStateContent;
            _objectResolver = objectResolver;
        }

        public override IPopup Create(object context)
        {
            WinPopupView view = InstantiateView(_levelStateContent.WinPopupPrefab);
            WinPopupPresenter presenter = CreatePresenter(view);
            return new WinPopup(presenter, view);
        }

        private WinPopupPresenter CreatePresenter(WinPopupView view)
        {
            WinPopupPresenter presenter = _objectResolver.Resolve<WinPopupPresenter>();
            presenter.BindView(view);
            return presenter;
        }
    }
}