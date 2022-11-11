using System;
using DG.Tweening;

namespace Game.Scripts.StateMachine
{
    public class Stage2Behaviour : StateMachineBase
    {
        public Stage2Behaviour(GameManager gameManager, SoundController soundController, VideoController videoController) : base(gameManager, soundController, videoController)
        {
        }
        
        public override void OnEnter(Action doOnEnter = null, string answer = null)
        {
            base.OnEnter(null);
            VideoController.StopVideo();
            SoundController.PlayVillageSound();
            

            var sequence = DOTween.Sequence();
          
            sequence.InsertCallback(40f,() =>
            {
                VideoController.PlayFatherVideoClip();
            });
            sequence.InsertCallback(75f,() =>
            {
                VideoController.PauseVideo();                

            });
            sequence.InsertCallback(77.2f,() =>
            {

                GameManager.ChangeStateTo(States.Stage3, null);
            });
            
            sequence.Play();
        }

        public override void OnExit(Action doOnExit = null)
        {
            VideoController.StopVideo();
            base.OnExit(null);
        }
    }
}
