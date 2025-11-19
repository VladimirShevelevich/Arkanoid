using VContainer;
using VContainer.Unity;

namespace Arkanoid.Platform
{
    public static class PlatformInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.UseEntryPoints(ep =>
            {
                ep.Add<PlatformService>();
            });
            builder.Register<PlatformFactory>(Lifetime.Scoped);
        }
    }
}