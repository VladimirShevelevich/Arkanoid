using System;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid.Popups
{
    public class PopupAbstractFactory
    {
        private static readonly Dictionary<PopupType, PopupFactory> _factoriesMap = new();

        public void RegisterFactory(PopupFactory factory)
        {
            _factoriesMap[factory.PopupType] = factory;
        }

        public IPopup CreatePopup(PopupType popupType)
        {
            var factory = GetFactory(popupType);
            return factory.Create();
        }

        private PopupFactory GetFactory(PopupType popupType)
        {
            if (_factoriesMap.TryGetValue(popupType, out PopupFactory factory))
            {
                return factory;
            }

            throw new InvalidOperationException($"The factory of type {popupType} hasn't been registered");
        }
    }
}