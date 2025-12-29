using Arkanoid.Popups;
using UnityEngine;
using VContainer;

namespace Arkanoid.LevelState.SecondChance
{
    public class SecondChancePopupFactory : PopupsFactory
    {
        private readonly LevelStateContent _levelStateContent;
        private readonly IObjectResolver _objectResolver;

        public SecondChancePopupFactory(Canvas mainCanvas, LevelStateContent levelStateContent, IObjectResolver objectResolver) : base(mainCanvas)
        {
            _levelStateContent = levelStateContent;
            _objectResolver = objectResolver;
        }
        
        public override IPopup Create()
        {
            SecondChancePopupView view = InstantiateView(_levelStateContent.SecondChancePopupPrefab);
            SecondChancePopupPresenter presenter = CreatePresenter(view);
            return presenter;
        }

        private SecondChancePopupPresenter CreatePresenter(SecondChancePopupView view)
        {
            SecondChancePopupPresenter presenter = _objectResolver.Resolve<SecondChancePopupPresenter>();
            presenter.BindView(view);
            return presenter;
        }
    }
}