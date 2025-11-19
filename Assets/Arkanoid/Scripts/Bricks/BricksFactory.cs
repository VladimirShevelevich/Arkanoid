using UnityEngine;

namespace Arkanoid.Bricks
{
    public class BricksFactory
    {
        private readonly BricksContent _bricksContent;

        public BricksFactory(BricksContent bricksContent)
        {
            _bricksContent = bricksContent;
        }
        
        public GameObject Create()
        {
            return Object.Instantiate(_bricksContent.BrickPrefab);
        }
    }
}