using UniRx;

namespace Arkanoid.LevelState
{
    public interface ILevelStateService
    {
        IReadOnlyReactiveProperty<LevelStateType> CurrentState { get; }
    }
}