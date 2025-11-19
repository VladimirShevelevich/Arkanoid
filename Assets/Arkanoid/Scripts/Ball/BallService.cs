using VContainer.Unity;

namespace Arkanoid.Ball
{
    public class BallService : IInitializable
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
            _ballFactory.Create();
        }
    }
}