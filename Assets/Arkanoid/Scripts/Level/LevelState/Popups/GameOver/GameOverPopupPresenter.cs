using System;
using Arkanoid.Level;

namespace Arkanoid.LevelState
{
    public class GameOverPopupPresenter : IDisposable
    {
        private readonly ILevelCreatorService _levelCreatorService;
        private GameOverPopupView _view;

        public GameOverPopupPresenter(ILevelCreatorService levelCreatorService)
        {
            _levelCreatorService = levelCreatorService;
        }
        
        public void BindView(GameOverPopupView view)
        {
            _view = view;
            _view.OnRestartClick += OnRestartClick;
        }

        private void OnRestartClick()
        {
            _levelCreatorService.ReloadLevel();
        }

        public void Dispose()
        {
            _view.OnRestartClick -= OnRestartClick;
        }
    }
}