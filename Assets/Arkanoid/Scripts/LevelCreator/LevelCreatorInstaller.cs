using VContainer;
using VContainer.Unity;

namespace Arkanoid.Level
{
    public static class LevelCreatorInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.UseEntryPoints(ep =>
            {
                ep.Add<LevelCreatorService>();
            });
        }
    }
}