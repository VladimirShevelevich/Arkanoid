using VContainer;

namespace Arkanoid.Platform
{
    public static class PlatformInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<PlatformFactory>(Lifetime.Scoped);
            builder.Register<IPlatformService, PlatformService>(Lifetime.Scoped);
        }
    }
}