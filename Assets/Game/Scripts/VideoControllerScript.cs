using System;
using UnityEngine;
using UnityEngine.Video;

namespace Game.Scripts
{
    public class VideoControllerScript : MonoBehaviour
    {
        [SerializeField] private VideoPlayer _videoPlayer;

        public void StartVideo()
        {
            _videoPlayer.Play();
        }

        public void PauseVideo()
        {
            _videoPlayer.Pause();
        }

        public void ContinueVideo()
        {
            _videoPlayer.Play();
        }

        private void FixedUpdate()
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                StartVideo();
                Debug.Log("Start Video");
            }
            
            if (Input.GetKeyDown(KeyCode.P))
            {
                PauseVideo();
                Debug.Log("Pause Video");
            }
            
            if (Input.GetKeyDown(KeyCode.C))
            {
                ContinueVideo();
                Debug.Log("Continue Video");
            }
        }
    }
}
