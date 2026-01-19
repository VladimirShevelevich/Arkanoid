using System;
using UniRx;
using VContainer.Unity;

namespace Arkanoid.LevelState
{
    public interface ILevelStateService : IInitializable
    {
        IReadOnlyReactiveProperty<Type> CurrentState { get; }
    }
}