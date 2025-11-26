using System;

namespace Arkanoid.LevelState.States
{
    public interface IWinCondition : IDisposable
    {
        event Action OnWin;
    }
}