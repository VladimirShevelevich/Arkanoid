using Arkanoid.Level;
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

        private Vector2 _brickSize;

        public BricksFactory(BricksContent bricksContent, GridContent gridContent, IObjectResolver objectResolver)
        {
            _bricksContent = bricksContent;
            _gridContent = gridContent;
            _objectResolver = objectResolver;
        }
        
        public IBrick Create(LevelConfig.BrickInfo brickInfo, Transform parent)
        {
            BrickView view = Object.Instantiate(_bricksContent.BrickPrefab, parent);
            if (_brickSize == default)
            {
                _brickSize = view.GetComponent<SpriteRenderer>().bounds.size;
            }
            
            Vector2 pos = GetPosition(_brickSize, brickInfo.GridPosition);
            view.transform.position = pos;
            BrickHealth health = CreateHealth(brickInfo.Health, view);
            
            _objectResolver.InjectGameObject(view.gameObject);
            health.Init();

            return new Brick(health, view);
        }

        private BrickHealth CreateHealth(int initialHealth, BrickView view)
        {
            return new BrickHealth(initialHealth, view);
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