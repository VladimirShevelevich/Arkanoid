using Arkanoid.Tools.Disposable;
using VContainer.Unity;

namespace Arkanoid.HUD
{
    public class HudService : BaseDisposable, IInitializable
    {
        private readonly HudFactory _hudFactory;

        public HudService(HudFactory hudFactory)
        {
            _hudFactory = hudFactory;
        }
        
        public void Initialize()
        {
            CreateHud();
        }

        private void CreateHud()
        {
            var hud = _hudFactory.Create();
            AddDisposable(new GameObjectDisposer(hud));
        }
    }
}