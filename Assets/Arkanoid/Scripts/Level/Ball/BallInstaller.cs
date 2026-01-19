using VContainer;
using VContainer.Unity;

namespace Arkanoid.Ball
{
    public static class BallInstaller
    {
        public static void Install(IContainerBuilder containerBuilder)
        {
            containerBuilder.Register<BallFactory>(Lifetime.Scoped);
            containerBuilder.Register<BallService>(Lifetime.Scoped);
        }
    }
}