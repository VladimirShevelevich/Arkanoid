using VContainer;
using VContainer.Unity;

namespace Arkanoid.Environment
{
    public static class EnvironmentInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.UseEntryPoints(ep =>
            {
                ep.Add<EnvironmentFactory>();
            });
        }
    }
}