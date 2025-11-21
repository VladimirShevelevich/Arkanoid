using Arkanoid.Level;
using Arkanoid.Popups;

namespace Arkanoid.LevelState
{
    public class GameOverPopupPresenter : IPopup
    {
        private readonly ILevelCreatorService _levelCreatorService;

        public GameOverPopupPresenter(ILevelCreatorService levelCreatorService)
        {
            _levelCreatorService = levelCreatorService;
        }
        
        public void BindView(GameOverPopupView view)
        {
            view.OnRestartClick += OnRestartClick;
        }

        private void OnRestartClick()
        {
            _levelCreatorService.ReloadLevel();
        }
    }
}