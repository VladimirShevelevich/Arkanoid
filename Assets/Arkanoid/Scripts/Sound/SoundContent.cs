using Arkanoid.Content;
using UnityEngine;

namespace Arkanoid.Sound
{
    [CreateAssetMenu(fileName = "SoundContent", menuName = "Content/Sound")]
    public class SoundContent : BaseContent
    {
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
    }
}