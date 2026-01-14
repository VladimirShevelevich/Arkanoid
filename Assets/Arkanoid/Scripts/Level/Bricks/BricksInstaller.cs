using VContainer;

namespace Arkanoid.Bricks
{
    public static class BricksInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<BricksFactory>(Lifetime.Scoped);
            builder.Register<IBricksService, BricksService>(Lifetime.Scoped);
        }
    }
}