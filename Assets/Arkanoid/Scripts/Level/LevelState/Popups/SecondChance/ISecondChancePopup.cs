using System;
using Arkanoid.Popups;
using UniRx;

namespace Arkanoid.LevelState.SecondChance
{
    public interface ISecondChancePopup : IPopup
    {
        IObservable<Unit> OnTryAgainCall { get; }
    }
}