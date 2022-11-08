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
            sequence.InsertCallback(.5f,() =>
            {
                VideoController.PlayWeddingVideoClip();

            });
            sequence.InsertCallback(.4f,() =>
            {
                List<string> sentences = new List<string>();
                sentences.Add("Hareket etme");
                GameManager.StartText(sentences, null);
            });
            sequence.InsertCallback(.6f,() =>
            {
                SoundController.PlayWeddingCrowdSound();
            });
            sequence.InsertCallback(10f,() =>
            {
                VideoController.PlaySecondWeddingVideoClip();
            });
            sequence.InsertCallback(10f,() =>
            {
                List<string> sentences = new List<string>();
                sentences.Add("Hareket etme");
                sentences.Add("Cevap verme");
                sentences.Add("Gülümse, memnuniyetsiz bir gelini kimse sevmez.");
                sentences.Add("Seni daha çok üzerler.");

                GameManager.StartText(sentences, () =>
                {
                    GameManager.ChangeStateTo(States.Stage6);
                });

            });

            sequence.Play();
        }

        public override void OnExit(Action doOnExit = null)
        {
            base.OnExit(null);
        }
        
    }
}