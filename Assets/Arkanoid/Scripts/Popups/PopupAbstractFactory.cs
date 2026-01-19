using System;
using System.Collections.Generic;
using Arkanoid.LevelState;
using Arkanoid.LevelState.SecondChance;
using VContainer;

namespace Arkanoid.Popups
{
    public class PopupAbstractFactory
    {
        private readonly IObjectResolver _objectResolver;

        public PopupAbstractFactory(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        private static readonly Dictionary<PopupType, Type> _factoriesMap = new()
        {
            { PopupType.Win, typeof(WinPopupFactory) },
            { PopupType.GameOver, typeof(GameOverPopupFactory) },
            { PopupType.SecondChance, typeof(SecondChancePopupFactory) }
        };

        public PopupFactory GetFactory(PopupType popupType)
        {
            if (_factoriesMap.TryGetValue(popupType, out Type factoryType))
            {
                var factory = _objectResolver.Resolve(factoryType);
                return (PopupFactory)factory;
            }

            throw new InvalidOperationException($"Can't resolve the popup factory of the type {popupType}");
        }
    }
}