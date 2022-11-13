using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

namespace Game.Scripts
{
    public class VideoController : MonoBehaviour
    {
        [SerializeField] private VideoPlayer _videoPlayer;

        [SerializeField] private VideoClip _fatherVideoClip;
        [SerializeField] private VideoClip _weddingVideoClip;
        [SerializeField] private VideoClip _secondWeddingVideoClip;

        public void PlayFatherVideoClip()
        {
            _videoPlayer.clip = _fatherVideoClip;
            _videoPlayer.Play();        
        }

        public void PlayWeddingVideoClip()
        {
            
            _videoPlayer.clip = _weddingVideoClip;
           
            _videoPlayer.Play();
            
        }
        
        public void PlaySecondWeddingVideoClip()
        {
            
            _videoPlayer.clip = _secondWeddingVideoClip;
            _videoPlayer.Play();
            
        }

        public void StopVideo()
        {
            _videoPlayer.Stop();
        }
        
        public void PauseVideo()
        {
            _videoPlayer.Pause();
        }

    }
}
