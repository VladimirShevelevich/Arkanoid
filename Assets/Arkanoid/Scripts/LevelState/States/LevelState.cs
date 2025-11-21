using System;

namespace Arkanoid.LevelState.States
{
    public interface ILevelState
    {
        event Action<ILevelState> SetState; 
    }
}