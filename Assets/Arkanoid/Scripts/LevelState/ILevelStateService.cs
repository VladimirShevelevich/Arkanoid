using System;
using UniRx;

namespace Arkanoid.LevelState
{
    public interface ILevelStateService
    {
        IReadOnlyReactiveProperty<Type> CurrentState { get; }
    }
}