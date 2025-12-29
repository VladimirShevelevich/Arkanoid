namespace Arkanoid.Popups
{
    public interface IPopupsService
    {
        /// <typeparam name="TFactory">Popup factory type</typeparam>
        void ShowPopup<TFactory>() where TFactory : PopupsFactory;
    }
}