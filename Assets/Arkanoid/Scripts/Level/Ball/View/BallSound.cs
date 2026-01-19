using System;
using Arkanoid.Sound;
using UnityEngine;
using VContainer;

namespace Arkanoid.Ball.View
{
    public class BallSound : MonoBehaviour
    {
        private ISoundService _soundService;
        private BallContent _ballContent;

        [Inject]
        public void Construct(BallContent ballContent, ISoundService soundService)
        {
            _soundService = soundService;
            _ballContent = ballContent;
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (((1 << other.gameObject.layer) & _ballContent.SoundLayerMask) != 0)
            {
                OnSoundCollision();
            }
        }

        private void OnSoundCollision()
        {
            _soundService.PlaySound(_ballContent.CollisionSound);
        }
    }
}