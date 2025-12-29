using System;
using Arkanoid.Popups;
using Arkanoid.Sound;

namespace Arkanoid.LevelState.States
{
    public class WinState : ILevelState
    {
        private readonly IPopupsService _popupsService;
        private readonly LevelStateContent _levelStateContent;
        private readonly ISoundService _soundService;
        public event Action<Type> SetState;

        public WinState(IPopupsService popupsService, LevelStateContent levelStateContent, ISoundService soundService)
        {
            _popupsService = popupsService;
            _levelStateContent = levelStateContent;
            _soundService = soundService;
        }
        
        public void Init()
        {
            _popupsService.ShowPopup<WinPopupFactory>();
            _soundService.PlaySound(_levelStateContent.WinSound);
        }

        public void Dispose()
        {
            
        }
    }
}