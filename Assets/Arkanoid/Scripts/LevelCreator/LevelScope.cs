using Arkanoid.Ball;
using Arkanoid.Bricks;
using Arkanoid.DeadZone;
using Arkanoid.Environment;
using Arkanoid.LevelState;
using Arkanoid.Platform;
using Arkanoid.Popups;
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
            DeadZoneInstaller.Install(builder);
            LevelStateInstaller.Install(builder);
            PopupsInstaller.Install(builder);
        }
    }
}