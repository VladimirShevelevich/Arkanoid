using UnityEngine;

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
            Transform parent = new GameObject("Grid").transform;
            for (int row = 0; row < _gridContent.GridRows; row++)
            {
                for (int col = 0; col < _gridContent.GridColumns; col++)
                {
                    GameObject brickGo = _bricksFactory.Create();
                    brickGo.transform.parent = parent;
                    Vector2 brickSize = brickGo.GetComponent<SpriteRenderer>().bounds.size;
                    
                    Vector2 pos = new Vector2(
                        _gridContent.GridStartPosition.x + col * (brickSize.x + _gridContent.GridHorizontalSpace),
                        _gridContent.GridStartPosition.y - row * (brickSize.y + _gridContent.GridVerticalSpace)
                    );
                    brickGo.transform.position = pos;
                }
            }
        }
    }
}