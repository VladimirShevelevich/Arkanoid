using System;
using Arkanoid.Tools.Disposable;
using UniRx;

namespace Arkanoid.LevelState.SecondChance
{
    public class SecondChancePopupPresenter : BaseDisposable, ISecondChancePopup
    {
        public IObservable<Unit> OnTryAgainCall => _onTryAgainCall;
        private readonly ReactiveCommand _onTryAgainCall = new();

        private SecondChancePopupView _view;

        public void BindView(SecondChancePopupView view)
        {
            _view = view;
            AddDisposable(new GameObjectDisposer(view.gameObject));

            _view.OnTryAgainClick += OnTryAgainClick;
        }

        private void OnTryAgainClick()
        {
            _onTryAgainCall.Execute();
        }
    }
}