using Arkanoid.Level;
using Arkanoid.Popups;

namespace Arkanoid.LevelState
{
    public class WinPopupPresenter : IPopup
    {
        private readonly ILevelCreatorService _levelCreatorService;

        public WinPopupPresenter(ILevelCreatorService levelCreatorService)
        {
            _levelCreatorService = levelCreatorService;
        }
        
        public void BindView(WinPopupView view)
        {
            view.OnNextLevelClick += OnNextLevelClick;
        }

        private void OnNextLevelClick()
        {
            _levelCreatorService.LoadNextLevel();
        }
    }
}