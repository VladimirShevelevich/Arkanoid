using VContainer;
using VContainer.Unity;

namespace Arkanoid.HUD
{
    public static class HudInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<HudFactory>(Lifetime.Scoped);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<HudService>();
            });
        }
    }
}