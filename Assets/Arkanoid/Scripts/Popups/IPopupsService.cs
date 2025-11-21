namespace Arkanoid.Popups
{
    public interface IPopupsService
    {
        /// <typeparam name="TFactory">Popup factory type</typeparam>
        void ShopPopup<TFactory>() where TFactory : PopupsFactory;
    }
}