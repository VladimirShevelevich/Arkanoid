using VContainer;

namespace Arkanoid.Popups
{
    public class PopupsService : IPopupsService
    {
        private readonly IObjectResolver _objectResolver;

        public PopupsService(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }
        
        public void ShopPopup<TFactory>() where TFactory : PopupsFactory
        {
            TFactory factory = _objectResolver.Resolve<TFactory>();
            IPopup popup = factory.Create();
        }
    }
}