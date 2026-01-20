namespace Arkanoid.Popups
{
    public interface IPopupsService
    {
        T ShowPopup<T>(PopupType popupType) where T : IPopup;
        void HidePopup(PopupType popupType);
    }
}