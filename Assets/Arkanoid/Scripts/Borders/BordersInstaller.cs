using VContainer;
using VContainer.Unity;

namespace Arkanoid.Borders
{
    public static class BordersInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<BordersFactory>(Lifetime.Scoped);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<BordersService>();
            });
        }
    }
}