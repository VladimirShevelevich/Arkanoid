using System;

namespace Arkanoid.LevelState.States
{
    public interface ILevelState : IDisposable
    {
        event Action<Type> SetState;
        void Init();
    }
}