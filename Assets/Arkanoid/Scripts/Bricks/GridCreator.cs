namespace Arkanoid.Bricks
{
    public class GridCreator
    {
        private readonly GridContent _gridContent;
        private readonly BricksFactory _bricksFactory;

        public GridCreator(GridContent gridContent, BricksFactory bricksFactory)
        {
            _gridContent = gridContent;
            _bricksFactory = bricksFactory;
        }
        
        public void Create()
        {
            
        }
    }
}