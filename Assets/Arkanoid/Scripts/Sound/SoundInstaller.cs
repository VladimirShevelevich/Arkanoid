using VContainer;
using VContainer.Unity;

namespace Arkanoid.Sound
{
    public static class SoundInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.UseEntryPoints(ep =>
            {
                ep.Add<SoundService>();
            });
        }
    }
}