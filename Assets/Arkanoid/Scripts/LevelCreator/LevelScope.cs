using Arkanoid.Environment;
using Arkanoid.Platform;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Arkanoid.Level
{
    public class LevelScope : LifetimeScope
    {
        [SerializeField] private LevelConfig _levelConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_levelConfig);
            EnvironmentInstaller.Install(builder);
            PlatformInstaller.Install(builder);
        }
    }
}