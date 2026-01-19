using VContainer;

namespace Arkanoid.LoadingScreen
{
    public static class LoadingScreenInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<LoadingScreenFactory>(Lifetime.Singleton);
            builder.Register<LoadingScreenService>(Lifetime.Singleton);
        }
    }
}