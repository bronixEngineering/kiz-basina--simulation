using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Scripts.StateMachine
{
    public class Stage4Behaviour : StateMachineBase
    {
        public Stage4Behaviour(GameManager gameManager, SoundController soundController, VideoController videoController) : base(gameManager, soundController, videoController)
        {
        }
        
        public override void OnEnter(Action doOnEnter = null, string answer = null)
        {
            base.OnEnter(null);
            GameManager.DecisionButtonActivate(false, null, answer);
            var sequence = DOTween.Sequence();
            sequence.InsertCallback(15f,() =>
            {
                GameManager.ChangeStateTo(States.Stage5, null);
            });
            
            sequence.Play();

        }

        public override void OnExit(Action doOnExit = null)
        {
            base.OnExit(null);
        }
        
    }
}
