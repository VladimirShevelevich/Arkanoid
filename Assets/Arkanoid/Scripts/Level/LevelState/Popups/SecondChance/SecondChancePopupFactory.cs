using Arkanoid.Popups;
using UnityEngine;
using VContainer;

namespace Arkanoid.LevelState.SecondChance
{
    public class SecondChancePopupFactory : PopupFactory
    {
        private readonly LevelStateContent _levelStateContent;
        private readonly IObjectResolver _objectResolver;

        public SecondChancePopupFactory(Canvas mainCanvas, LevelStateContent levelStateContent, IObjectResolver objectResolver) : base(mainCanvas)
        {
            _levelStateContent = levelStateContent;
            _objectResolver = objectResolver;
        }
        
        public override IPopup Create(object context)
        {
            SecondChancePopupView view = InstantiateView(_levelStateContent.SecondChancePopupPrefab);
            SecondChancePopupPresenter presenter = CreatePresenter(view, context);
            return presenter;
        }

        private SecondChancePopupPresenter CreatePresenter(SecondChancePopupView view, object context)
        {
            SecondChancePopupPresenter presenter = _objectResolver.Resolve<SecondChancePopupPresenter>();
            presenter.SetContext((SecondChancePopupContext)context);
            presenter.BindView(view);
            return presenter;
        }
    }
}