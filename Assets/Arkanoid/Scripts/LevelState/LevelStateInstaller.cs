using VContainer;
using VContainer.Unity;

namespace Arkanoid.LevelState
{
    public static class LevelStateInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.UseEntryPoints(ep =>
            {
                ep.Add<LevelStateService>();
            });
            RegisterPopups(builder);
        }

        private static void RegisterPopups(IContainerBuilder builder)
        {
            builder.Register<GameOverPopupFactory>(Lifetime.Singleton).AsSelf();
            builder.Register<GameOverPopupPresenter>(Lifetime.Transient).AsSelf();
        }
    }
}