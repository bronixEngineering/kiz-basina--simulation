using System;
using System.Collections.Generic;
using DG.Tweening;

namespace Game.Scripts.StateMachine
{
    public class Stage6Behaviour : StateMachineBase
    {
        public Stage6Behaviour(GameManager gameManager, SoundController soundController, VideoController videoController) : base(gameManager, soundController, videoController)
        {
        }
        
        public override void OnEnter(Action doOnEnter = null, string answer = null)
        {
            base.OnEnter(null);
            List<string> sentences = new List<string>();

            sentences.Add("Bu hayatı değiştirmek istiyor musun");
            GameManager.StartText(sentences, 5f,null);
            GameManager.SecondDecisionButtonActivate(true, null, null);
        }

        public override void OnExit(Action doOnExit = null)
        {
            base.OnExit(null);
        }
    }
}