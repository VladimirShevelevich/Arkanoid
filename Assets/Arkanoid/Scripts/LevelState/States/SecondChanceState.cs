using System;
using Arkanoid.LevelState.SecondChance;
using Arkanoid.Popups;
using UniRx;

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
            _popupsService.ShowPopup<SecondChancePopupFactory>();    
        }

        public void Dispose()
        {
            
        }
    }
}