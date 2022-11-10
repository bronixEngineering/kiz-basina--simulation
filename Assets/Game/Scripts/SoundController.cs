using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Scripts
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private RightHandBehaviour _rightHandBehaviour;
        [SerializeField] private LeftHandBehaviour _leftHandBehaviour;

        [SerializeField] private AudioClip _villlageSounds;
        [SerializeField] private AudioClip _crowdedSounds;
        [SerializeField] private AudioClip _weddingCrowdSounds;
        [SerializeField] private AudioClip _yesOptionSounds;
        [SerializeField] private AudioClip _noOptionSounds;
        [SerializeField] private AudioClip _pianoSound;

        private IEnumerator _soundRoutine;
        
        public void PlayCrowdSoundWithDelay(int delay, [CanBeNull] Action completeAction)
        {
            if (_soundRoutine != null)
                StopCoroutine(_soundRoutine);

            _soundRoutine = PlayCrowdSoundRoutine(delay, completeAction);
            StartCoroutine(_soundRoutine);
        }
        private IEnumerator PlayCrowdSoundRoutine(int delay, [CanBeNull] Action completeAction)
        {
            yield return new WaitForSeconds(delay);
            
            _audioSource.Stop();
            _audioSource.clip = _crowdedSounds;
            _audioSource.Play();

            yield return new WaitForSeconds(delay);
            completeAction?.Invoke();

        }

        public void PlayCrowdSound()
        {
            _audioSource.clip = _crowdedSounds;
            _audioSource.Play();
        }
        public void PlayPianoSound()
        {
            _audioSource.clip = _pianoSound;
            _audioSource.Play();
        }

        public void PlayVillageSound()
        {
            _audioSource.clip = _villlageSounds;
            _audioSource.Play();
        }
        public void PlayYesSound()
        {
            _audioSource.clip = _yesOptionSounds;
            _audioSource.Play();
        }
        public void PlayNoSound()
        {
            _audioSource.clip = _noOptionSounds;
            _audioSource.Play();
        }

        public void PlayWeddingCrowdSound()
        {
            _audioSource.clip = _weddingCrowdSounds;
            _audioSource.Play();
        }

        public void StopSound()
        {
            _audioSource.Stop();
        }
        
    }
}
