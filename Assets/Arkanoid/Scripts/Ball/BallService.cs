using Arkanoid.Tools.Disposable;
using VContainer.Unity;

namespace Arkanoid.Ball
{
    public class BallService : BaseDisposable, IInitializable
    {
        private readonly BallFactory _ballFactory;

        public BallService(BallFactory ballFactory)
        {
            _ballFactory = ballFactory;
        }
        
        public void Initialize()
        {
            CreateBall();
        }

        private void CreateBall()
        {
            var go = _ballFactory.Create();
            AddDisposable(new GameObjectDisposer(go));
        }
    }
}