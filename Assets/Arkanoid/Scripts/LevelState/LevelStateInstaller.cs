using Arkanoid.LevelState.States;
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
            RegisterStates(builder);
            RegisterWinCondition(builder);
        }

        private static void RegisterPopups(IContainerBuilder builder)
        {
            builder.Register<GameOverPopupFactory>(Lifetime.Singleton).AsSelf();
            builder.Register<GameOverPopupPresenter>(Lifetime.Singleton).AsSelf();
            
            builder.Register<WinPopupFactory>(Lifetime.Singleton).AsSelf();
            builder.Register<WinPopupPresenter>(Lifetime.Transient).AsSelf();
        }

        private static void RegisterStates(IContainerBuilder builder)
        {
            builder.Register<GameplayState>(Lifetime.Transient);
            builder.Register<GameOverState>(Lifetime.Transient);
            builder.Register<WinState>(Lifetime.Transient);
            builder.Register<SecondChanceState>(Lifetime.Transient);
        }

        private static void RegisterWinCondition(IContainerBuilder containerBuilder)
        {
            containerBuilder.Register<IWinCondition, BricksOverWinCondition>(Lifetime.Transient);
        }
    }
}