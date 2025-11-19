using VContainer;
using VContainer.Unity;

namespace Arkanoid.Bricks
{
    public static class BricksInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<BricksFactory>(Lifetime.Scoped);
            builder.Register<GridCreator>(Lifetime.Scoped);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<BricksService>();
            });
        }
    }
}