using System;

namespace Arkanoid.LevelState.States
{
    public class GameplayState : ILevelState
    {
        public event Action<ILevelState> SetState;
    }
}