using System;
using UnityEngine;
using VContainer;

namespace Arkanoid.DeadZone
{
    public class DeadZoneView : MonoBehaviour
    {
        public event Action OnTriggered;
        
        private DeadZoneContent _deadZoneContent;

        [Inject]
        public void Construct(DeadZoneContent deadZoneContent)
        {
            _deadZoneContent = deadZoneContent;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (((1 << other.gameObject.layer) & _deadZoneContent.CollisionLayer) != 0)
            {
                OnTriggered?.Invoke();
            }
        }

    }
}