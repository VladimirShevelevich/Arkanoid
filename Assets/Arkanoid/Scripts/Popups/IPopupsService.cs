namespace Arkanoid.Popups
{
    public interface IPopupsService
    {
        /// <typeparam name="TFactory">Popup factory type</typeparam>
        void ShowPopup(PopupType popupType, object context = null);
        void HidePopup(PopupType popupType);
    }
}