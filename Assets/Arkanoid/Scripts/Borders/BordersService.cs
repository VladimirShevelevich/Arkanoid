using Arkanoid.Tools.Disposable;
using UnityEngine;
using VContainer.Unity;

namespace Arkanoid.Borders
{
    public class BordersService : BaseDisposable, IBordersService, IInitializable
    {
        public Bounds LeftBorderBounds => _view.LeftBorderCollider.bounds;
        public Bounds RightBorderBounds => _view.RightBorderCollider.bounds;
        
        private readonly BordersFactory _bordersFactory;
        private BordersView _view;

        public BordersService(BordersFactory bordersFactory)
        {
            _bordersFactory = bordersFactory;
        }
        
        public void Initialize()
        {
            Create();
        }

        private void Create()
        {
            _view = _bordersFactory.Create();
            AddDisposable(new GameObjectDisposer(_view.gameObject));
        }
    }
}