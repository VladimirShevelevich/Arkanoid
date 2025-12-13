using System;
using Arkanoid.Level;

namespace Arkanoid.Bricks
{
    public interface IBricksService
    {
        event Action<LevelConfig.BrickInfo> OnBrickDestroyed;
    }
}