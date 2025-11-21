using Arkanoid.Popups;
using UnityEngine;
using VContainer;

namespace Arkanoid.LevelState
{
    public class GameOverPopupFactory : PopupsFactory
    {
        private readonly LevelStateContent _levelStateContent;
        private readonly IObjectResolver _objectResolver;

        public GameOverPopupFactory(LevelStateContent levelStateContent, IObjectResolver objectResolver, Canvas mainCanvas) : base(mainCanvas) 
        {
            _levelStateContent = levelStateContent;
            _objectResolver = objectResolver;
        }
        
        public override IPopup Create()
        {
            GameOverPopupView view = InstantiateView(_levelStateContent.GameOverPopupPrefab);
            GameOverPopupPresenter presenter = CreatePresenter(view);
            return new GameOverPopup(presenter, view);
        }

        private GameOverPopupPresenter CreatePresenter(GameOverPopupView view)
        {
            GameOverPopupPresenter presenter = _objectResolver.Resolve<GameOverPopupPresenter>();
            presenter.BindView(view);
            return presenter;
        }
    }
}