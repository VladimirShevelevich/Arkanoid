namespace Arkanoid.Popups
{
    public interface IPopupsService
    {
        /// <typeparam name="TFactory">Popup factory type</typeparam>
        void ShowPopup<TFactory>(object context = null) where TFactory : PopupsFactory;
        void HidePopup<TFactory>() where TFactory : PopupsFactory;
    }
}