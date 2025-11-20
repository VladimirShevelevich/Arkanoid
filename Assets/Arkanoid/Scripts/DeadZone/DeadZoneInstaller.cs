using VContainer;
using VContainer.Unity;

namespace Arkanoid.DeadZone
{
    public static class DeadZoneInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<DeadZoneFactory>(Lifetime.Scoped);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<DeadZoneService>();
            });
        }
    }
}