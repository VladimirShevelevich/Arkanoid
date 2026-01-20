using Arkanoid.LevelState.SecondChance;
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
                ep.Add<LevelStateService>().AsSelf();
            });
            RegisterPopups(builder);
            RegisterStates(builder);
            RegisterWinCondition(builder);
            
            builder.Register<SecondChanceController>(Lifetime.Scoped);
        }

        private static void RegisterPopups(IContainerBuilder builder)
        {
            builder.Register<GameOverPopupFactory>(Lifetime.Singleton).AsSelf();
            builder.Register<GameOverPopupPresenter>(Lifetime.Singleton).AsSelf();
            
            builder.Register<WinPopupFactory>(Lifetime.Singleton).AsSelf();
            builder.Register<WinPopupPresenter>(Lifetime.Transient).AsSelf();
            
            builder.Register<SecondChancePopupFactory>(Lifetime.Singleton).AsSelf();
            builder.Register<SecondChancePopupPresenter>(Lifetime.Transient).AsSelf();
            
            builder.UseEntryPoints(ep =>
            {
                ep.Add<WinPopupFactory>();
                ep.Add<GameOverPopupFactory>();
                ep.Add<SecondChancePopupFactory>();
            });
        }

        private static void RegisterStates(IContainerBuilder builder)
        {
            builder.Register<GameplayState>(Lifetime.Transient);
            builder.Register<GameOverState>(Lifetime.Transient);
            builder.Register<WinState>(Lifetime.Transient);
            builder.Register<SecondChanceState>(Lifetime.Transient);
            builder.Register<LoadingState>(Lifetime.Transient);
        }

        private static void RegisterWinCondition(IContainerBuilder containerBuilder)
        {
            containerBuilder.Register<IWinCondition, BricksOverWinCondition>(Lifetime.Transient);
        }
    }
}