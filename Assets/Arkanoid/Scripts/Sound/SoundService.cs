using UnityEngine;
using VContainer.Unity;

namespace Arkanoid.Sound
{
    public class SoundService : ISoundService, IInitializable
    {
        private readonly SoundContent _soundContent;
        private AudioSource _audioSource;

        public SoundService(SoundContent soundContent)
        {
            _soundContent = soundContent;
        }

        public void Initialize()
        {
            _audioSource = Object.Instantiate(_soundContent.AudioSource);
        }

        public void PlaySound(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }
    }
}