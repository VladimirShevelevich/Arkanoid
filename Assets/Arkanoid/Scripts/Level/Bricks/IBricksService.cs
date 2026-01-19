using System;
using Arkanoid.Level;
using Arkanoid.Tools.Initialization;

namespace Arkanoid.Bricks
{
    public interface IBricksService : IAsyncInitializable
    {
        event Action<LevelConfig.BrickInfo> OnBrickDestroyed;
    }
}