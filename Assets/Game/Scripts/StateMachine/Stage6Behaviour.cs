using System;
using System.Collections.Generic;

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
            GameManager.StartText(sentences, null);
            GameManager.SecondDecisionButtonActivate(true, null);
        }

        public override void OnExit(Action doOnExit = null)
        {
            base.OnExit(null);
        }
    }
}