using System;
using Arkanoid.Level;

namespace Arkanoid.Bricks
{
    public interface IBrick : IDisposable
    {
        event Action<LevelConfig.BrickInfo> OnDestroyed;
    }
}