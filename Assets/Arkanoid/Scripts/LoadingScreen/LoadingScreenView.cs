using DG.Tweening;
using UnityEngine;

namespace Arkanoid.LoadingScreen
{
    public class LoadingScreenView : MonoBehaviour
    {
        [SerializeField] private Transform _image;
    
        void Start()
        {
            StartAnimation();
        }

        private void StartAnimation()
        {
            _image
                .DORotate(new Vector3(0, 0, -360), 3f, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear)
                .SetLink(gameObject);
        }
    }
}