using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Arkanoid.Bricks
{
    public class BricksFactory
    {
        private readonly BricksContent _bricksContent;
        private readonly GridContent _gridContent;
        private readonly IObjectResolver _objectResolver;

        public BricksFactory(BricksContent bricksContent, GridContent gridContent, IObjectResolver objectResolver)
        {
            _bricksContent = bricksContent;
            _gridContent = gridContent;
            _objectResolver = objectResolver;
        }
        
        public GameObject Create(Vector2Int gridPosition)
        {
            GameObject go = Object.Instantiate(_bricksContent.BrickPrefab);
            Vector2 brickSize = go.GetComponent<SpriteRenderer>().bounds.size;
            Vector2 pos = GetPosition(brickSize, gridPosition);
            go.transform.position = pos;
            _objectResolver.InjectGameObject(go);
            return go;
        }

        private Vector2 GetPosition(Vector2 brickSize, Vector2Int gridPosition)
        {
            int column = gridPosition.x;
            int row = gridPosition.y;

            return new Vector2(
                _gridContent.GridStartPosition.x + column * (brickSize.x + _gridContent.GridHorizontalSpace),
                _gridContent.GridStartPosition.y - row * (brickSize.y + _gridContent.GridVerticalSpace));
        }

    }
}