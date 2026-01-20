using System;
using Arkanoid.Popups;
using Arkanoid.Sound;
using Arkanoid.Tools.Disposable;

namespace Arkanoid.LevelState.States
{
    public class WinState : BaseDisposable, ILevelState
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
            var popup = _popupsService.ShowPopup<IPopup>(PopupType.Win);
            AddDisposable(popup);
            _soundService.PlaySound(_levelStateContent.WinSound);
        }
    }
}