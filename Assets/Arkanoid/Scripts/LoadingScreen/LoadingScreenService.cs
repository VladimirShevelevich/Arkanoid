using Arkanoid.Tools.Disposable;

namespace Arkanoid.LoadingScreen
{
    public class LoadingScreenService : BaseDisposable
    {
        private readonly LoadingScreenFactory _loadingScreenFactory;
        private LoadingScreenView _view;

        public LoadingScreenService(LoadingScreenFactory loadingScreenFactory)
        {
            _loadingScreenFactory = loadingScreenFactory;
        }
        
        public void Show()
        {
            if (_view == null) 
                CreateView();

            _view.gameObject.SetActive(true);
        }

        public void Hide()
        {
            if (_view == null)
                return;
            
            _view.gameObject.SetActive(false);
        }

        private void CreateView()
        {
            _view = _loadingScreenFactory.Create();
            AddDisposable(new GameObjectDisposer(_view.gameObject));
        }
    }
}