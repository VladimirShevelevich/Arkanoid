using UnityEngine;

namespace Arkanoid.Borders
{
    public class BordersFactory
    {
        private readonly BordersContent _content;

        public BordersFactory(BordersContent content)
        {
            _content = content;
        }

        public BordersView Create()
        {
            var view = Object.Instantiate(_content.BordersPrefab);
            return view;
        }
    }
}