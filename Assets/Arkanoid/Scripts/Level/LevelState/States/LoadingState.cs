using System;

namespace Arkanoid.LevelState.States
{
    public class LoadingState : ILevelState
    {
        public event Action<Type> SetState;

        public void Init()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}