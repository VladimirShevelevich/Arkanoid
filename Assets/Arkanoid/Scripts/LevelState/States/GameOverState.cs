using System;
using Arkanoid.Popups;
using Arkanoid.Sound;

namespace Arkanoid.LevelState.States
{
    public class GameOverState : ILevelState
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
            _popupsService.ShopPopup<GameOverPopupFactory>();
            _soundService.PlaySound(_levelStateContent.GameOverSound);
        }

        public void Dispose()
        {
            
        }
    }
}