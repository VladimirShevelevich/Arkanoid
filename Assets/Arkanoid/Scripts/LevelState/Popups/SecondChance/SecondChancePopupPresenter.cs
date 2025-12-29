using Arkanoid.Popups;
using Arkanoid.Tools.Disposable;

namespace Arkanoid.LevelState.SecondChance
{
    public class SecondChancePopupPresenter : BaseDisposable, IPopup
    {
        private SecondChancePopupView _view;

        public void BindView(SecondChancePopupView view)
        {
            _view = view;
            AddDisposable(new GameObjectDisposer(view.gameObject));

            _view.OnTryAgainClick += OnTryAgainClick;
        }

        private void OnTryAgainClick()
        {
            
        }
    }
}