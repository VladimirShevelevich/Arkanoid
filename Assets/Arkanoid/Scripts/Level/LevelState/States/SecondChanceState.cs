using System;
using Arkanoid.LevelState.SecondChance;
using Arkanoid.Popups;

namespace Arkanoid.LevelState.States
{
    public class SecondChanceState : ILevelState
    {
        public event Action<Type> SetState;
        
        private readonly IPopupsService _popupsService;

        public SecondChanceState(IPopupsService popupsService)
        {
            _popupsService = popupsService;
        }
        
        public void Init()
        {
            _popupsService.ShowPopup(PopupType.SecondChance, new SecondChancePopupContext
            {
                OnTryAgainCall = OnTryAgainCall
            });    
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