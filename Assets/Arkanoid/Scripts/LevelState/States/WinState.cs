using System;
using Arkanoid.Popups;

namespace Arkanoid.LevelState.States
{
    public class WinState : ILevelState
    {
        private readonly IPopupsService _popupsService;
        public event Action<Type> SetState;

        public WinState(IPopupsService popupsService)
        {
            _popupsService = popupsService;
        }
        
        public void Init()
        {
            _popupsService.ShopPopup<WinPopupFactory>();
        }

        public void Dispose()
        {
            
        }
    }
}