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
            if (_factoriesMap.ContainsKey(factory.PopupType))
            {
                Debug.LogWarning($"The factory of type {factory.PopupType} has already been registered");
                return;
            }
            
            _factoriesMap.Add(factory.PopupType, factory);
        }

        public void UnregisterFactory(PopupFactory factory)
        {
            if (_factoriesMap.TryGetValue(factory.PopupType, out var f))
            {
                _factoriesMap.Remove(factory.PopupType);
            }
            
            Debug.LogWarning($"The factory of type {factory.PopupType} hasn't been registered");
        }

        public IPopup CreatePopup(PopupType popupType, object context)
        {
            var factory = GetFactory(popupType);
            return factory.Create(context);
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