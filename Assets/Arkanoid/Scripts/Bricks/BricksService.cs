using VContainer.Unity;

namespace Arkanoid.Bricks
{
    public class BricksService : IInitializable
    {
        private readonly GridCreator _gridCreator;

        public BricksService(GridCreator gridCreator)
        {
            _gridCreator = gridCreator;
        }
        
        public void Initialize()
        {
            _gridCreator.Create();
        }
    }
}