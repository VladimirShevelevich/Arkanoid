using Arkanoid.Popups;
using Arkanoid.Tools.Disposable;

namespace Arkanoid.LevelState
{
    /// <summary>
    /// Facade used by PopupsService
    /// </summary>
    public class WinPopup : BaseDisposable, IPopup
    {
        public WinPopup(WinPopupPresenter presenter, WinPopupView view)
        {
            AddDisposable(presenter);
            AddDisposable(new GameObjectDisposer(view.gameObject));
        }
    }
}