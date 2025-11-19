using Arkanoid.Ball;
using Arkanoid.Bricks;
using Arkanoid.Environment;
using Arkanoid.Platform;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Arkanoid.Level
{
    public class LevelScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            EnvironmentInstaller.Install(builder);
            PlatformInstaller.Install(builder);
            BallInstaller.Install(builder);
            BricksInstaller.Install(builder);
        }
    }
}