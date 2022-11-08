using System;
using System.Collections.Generic;

namespace Game.Scripts.StateMachine
{
    public class Stage3Behaviour : StateMachineBase
    {
        public Stage3Behaviour(GameManager gameManager, SoundController soundController, VideoController videoController) : base(gameManager, soundController, videoController)
        {
        }
        
        public override void OnEnter(Action doOnEnter = null, string answer = null)
        {
            base.OnEnter(null);
            List<string> sentences = new List<string>();

            sentences.Add("Evliliğe hazır mıyım?");
            GameManager.StartText(sentences, null);
            GameManager.DecisionButtonActivate(true, null, null);
        }

        public override void OnExit(Action doOnExit = null)
        {
            base.OnExit(null);
        }
    }
}
