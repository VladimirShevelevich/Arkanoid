using System;
using Arkanoid.LevelState.SecondChance;
using Arkanoid.Popups;
using Arkanoid.Tools.Disposable;
using UniRx;

namespace Arkanoid.LevelState.States
{
    public class SecondChanceState : BaseDisposable, ILevelState
    {
        public event Action<Type> SetState;
        
        private readonly IPopupsService _popupsService;
        private readonly SecondChanceController _secondChanceController;

        public SecondChanceState(IPopupsService popupsService, SecondChanceController secondChanceController)
        {
            _popupsService = popupsService;
            _secondChanceController = secondChanceController;
        }
        
        public void Init()
        {
            ShowPopup();
            _secondChanceController.OnSecondChanceUsed();
        }

        private void ShowPopup()
        {
            var popup = _popupsService.ShowPopup<ISecondChancePopup>(PopupType.SecondChance);
            AddDisposable(popup);
            AddDisposable(popup.OnTryAgainCall.Subscribe(_ => OnTryAgainCall()));
        }

        private void OnTryAgainCall()
        {
            SetState?.Invoke(typeof(GameplayState));
        }

        public void Dispose()
        {
            _popupsService.HidePopup(PopupType.SecondChance);
        }
    }
}