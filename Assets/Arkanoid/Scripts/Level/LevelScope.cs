using Arkanoid.Ball;
using Arkanoid.Borders;
using Arkanoid.Bricks;
using Arkanoid.DeadZone;
using Arkanoid.HUD;
using Arkanoid.LevelInitialization;
using Arkanoid.LevelState;
using Arkanoid.Platform;
using Arkanoid.Popups;
using Arkanoid.Score;
using VContainer;
using VContainer.Unity;

namespace Arkanoid.Level
{
    public class LevelScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            BordersInstaller.Install(builder);
            PlatformInstaller.Install(builder);
            BallInstaller.Install(builder);
            BricksInstaller.Install(builder);
            DeadZoneInstaller.Install(builder);
            LevelStateInstaller.Install(builder);
            PopupsInstaller.Install(builder);
            ScoreInstaller.Install(builder);
            HudInstaller.Install(builder);

            builder.RegisterEntryPoint<InitializationQueue>();
        }
    }
}