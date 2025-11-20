namespace Arkanoid.Popups
{
    public interface IPopupsService
    {
        void Create<TFactory>() where TFactory : PopupsFactory;
    }
}