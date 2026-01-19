using System;
using Arkanoid.Level;

namespace Arkanoid.LevelState
{
    public class WinPopupPresenter : IDisposable
    {
        private readonly ILevelCreatorService _levelCreatorService;
        private WinPopupView _view;

        public WinPopupPresenter(ILevelCreatorService levelCreatorService)
        {
            _levelCreatorService = levelCreatorService;
        }
        
        public void BindView(WinPopupView view)
        {
            _view = view;
            _view.OnNextLevelClick += OnNextLevelClick;
        }

        private void OnNextLevelClick()
        {
            _levelCreatorService.LoadNextLevel();
        }

        public void Dispose()
        {
            _view.OnNextLevelClick -= OnNextLevelClick;
        }
    }
}