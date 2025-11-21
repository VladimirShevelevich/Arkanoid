using System;
using Arkanoid.LevelState.States;
using UniRx;

namespace Arkanoid.LevelState
{
    public interface ILevelStateService
    {
        IReadOnlyReactiveProperty<Type> CurrentState { get; }
    }
}