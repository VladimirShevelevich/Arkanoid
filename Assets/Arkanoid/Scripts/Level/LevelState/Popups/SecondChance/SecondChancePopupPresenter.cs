using System;
using Arkanoid.Popups;
using Arkanoid.Tools.Disposable;

namespace Arkanoid.LevelState.SecondChance
{
    public class SecondChancePopupPresenter : BaseDisposable, IPopup
    {
        private SecondChancePopupView _view;
        private Action _onTryAgainCall;

        public void SetContext(SecondChancePopupContext context)
        {
            _onTryAgainCall = context.OnTryAgainCall;
        }
        
        public void BindView(SecondChancePopupView view)
        {
            _view = view;
            AddDisposable(new GameObjectDisposer(view.gameObject));

            _view.OnTryAgainClick += OnTryAgainClick;
        }

        private void OnTryAgainClick()
        {
            _onTryAgainCall?.Invoke();            
        }
    }
}