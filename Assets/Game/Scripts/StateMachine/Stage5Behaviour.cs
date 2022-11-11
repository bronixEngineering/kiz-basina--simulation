using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.StateMachine
{
    public class Stage5Behaviour : StateMachineBase
    {
        public Stage5Behaviour(GameManager gameManager, SoundController soundController, VideoController videoController) : base(gameManager, soundController, videoController)
        {
        }
        
        public override void OnEnter(Action doOnEnter = null, string answer = null)
        {
            base.OnEnter(null);
            var sequence = DOTween.Sequence();
            GameManager.SpotLightOpen(6);
            sequence.InsertCallback(.1f,() =>
            {
                GameManager.ChangeHeadModel();
            });
            sequence.InsertCallback(2.5f,() =>
            {
                VideoController.PlayWeddingVideoClip();

            });
            sequence.InsertCallback(.4f,() =>
            {
                List<string> sentences = new List<string>();
                sentences.Add("Hareket etme");
                GameManager.StartText(sentences, 3.5f,null);
            });
            sequence.InsertCallback(2.6f,() =>
            {
                SoundController.PlayWeddingCrowdSound();
            });
          
            sequence.InsertCallback(12f,() =>
            {
                List<string> sentences = new List<string>();
                sentences.Add("Hareket etme");
                sentences.Add("Cevap verme");
                sentences.Add("Gülümse, memnuniyetsiz bir gelini kimse sevmez.");
                sentences.Add("Seni daha çok üzerler.");

                GameManager.StartText(sentences, 3.5f,null);

            });
           
            sequence.InsertCallback(51.7f, () =>
            {

                GameManager.ChangeStateTo(States.Stage6, null);
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