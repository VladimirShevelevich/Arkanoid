using VContainer;
using VContainer.Unity;

namespace Arkanoid.LevelState
{
    public static class LevelStateInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.UseEntryPoints(ep =>
            {
                ep.Add<LevelStateService>();
            });
        }
    }
}