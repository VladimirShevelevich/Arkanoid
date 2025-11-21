using System;
using Arkanoid.Popups;

namespace Arkanoid.LevelState.States
{
    public class GameOverState : ILevelState
    {
        private readonly IPopupsService _popupsService;

        public GameOverState(IPopupsService popupsService)
        {
            _popupsService = popupsService;
        }

        public event Action<Type> SetState;

        public void Init()
        {
            _popupsService.ShopPopup<GameOverPopupFactory>();
        }

        public void Dispose()
        {
            
        }
    }
}