using Arkanoid.Popups;
using Arkanoid.Tools.Disposable;

namespace Arkanoid.LevelState
{
    /// <summary>
    /// Facade used by PopupsService
    /// </summary>
    public class GameOverPopup : BaseDisposable, IPopup
    {
        public GameOverPopup(GameOverPopupPresenter presenter, GameOverPopupView view)
        {
            AddDisposable(presenter);
            AddDisposable(new GameObjectDisposer(view.gameObject));
        }

        public void Hide()
        {
            
        }
    }
}