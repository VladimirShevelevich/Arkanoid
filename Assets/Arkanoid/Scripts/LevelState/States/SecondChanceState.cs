using System;
using UniRx;

namespace Arkanoid.LevelState.States
{
    public class SecondChanceState : ILevelState
    {
        public event Action<Type> SetState;

        public void Init()
        {
            Observable.Timer(TimeSpan.FromSeconds(3)).Subscribe(_ => { SetState.Invoke(typeof(GameplayState)); });
        }

        public void Dispose()
        {
            
        }
    }
}