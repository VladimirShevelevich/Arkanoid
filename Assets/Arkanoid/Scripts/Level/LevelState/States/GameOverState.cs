using System;
using Arkanoid.Popups;
using Arkanoid.Sound;
using Arkanoid.Tools.Disposable;

namespace Arkanoid.LevelState.States
{
    public class GameOverState : BaseDisposable, ILevelState
    {
        private readonly IPopupsService _popupsService;
        private readonly ISoundService _soundService;
        private readonly LevelStateContent _levelStateContent;

        public GameOverState(IPopupsService popupsService, ISoundService soundService, LevelStateContent levelStateContent)
        {
            _popupsService = popupsService;
            _soundService = soundService;
            _levelStateContent = levelStateContent;
        }

        public event Action<Type> SetState;

        public void Init()
        {
            var popup = _popupsService.ShowPopup<IPopup>(PopupType.GameOver);
            AddDisposable(popup);
            
            _soundService.PlaySound(_levelStateContent.GameOverSound);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}