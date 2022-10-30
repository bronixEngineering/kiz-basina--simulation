using System;
using UnityEngine;

namespace Game.Scripts
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private RightHandBehaviour _rightHandBehaviour;
        [SerializeField] private RightHandBehaviour _leftHandBehaviour;


        [SerializeField] private AudioClip _clip1;
        [SerializeField] private AudioClip _clip2;
        [SerializeField] private AudioClip _clip3;
        [SerializeField] private AudioClip _clip4;

        private void Start()
        {
            _rightHandBehaviour.StartButtonInteracted += OnStartButtonInteracted;
            _leftHandBehaviour.StartButtonInteracted += OnStartButtonInteracted;
            _rightHandBehaviour.NameButtonInteracted += OnNameButtonInteracted;
        }

        private void OnStartButtonInteracted()
        {
            _audioSource.Stop();
        }
        private void OnNameButtonInteracted(string name)
        {
            _audioSource.Stop();

            if (name == "Name1")
            {
                _audioSource.clip = _clip1;
                _audioSource.Play();
            }
            else if (name == "Name2")
            {
                _audioSource.clip = _clip2;
                _audioSource.Play();
            }
            else if (name == "Name3")
            {
                _audioSource.clip = _clip3;
                _audioSource.Play();
            }
            else if (name == "Name4")
            {
                _audioSource.clip = _clip4;
                _audioSource.Play();
            }
                
        }

        private void OnDestroy()
        {
            _rightHandBehaviour.StartButtonInteracted -= OnStartButtonInteracted;
            _leftHandBehaviour.StartButtonInteracted -= OnStartButtonInteracted;
            _rightHandBehaviour.NameButtonInteracted -= OnNameButtonInteracted;
        }
    }
}
