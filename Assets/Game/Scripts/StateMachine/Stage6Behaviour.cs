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
            GameManager.StartText(sentences, null);
            GameManager.SecondDecisionButtonActivate(false, () =>
            {
                if (answer == "yes")
                {
                    List<string> sentences = new List<string>();
                    sentences.Add("Yanlış. Doğduğun günden beri sana ait olmayan bir hayatı, nasıl sahiplenip değiştirebilirsin?");
                    GameManager.StartText(sentences, null);
                }
                else
                {
                    List<string> sentences = new List<string>();
                    sentences.Add("Bir söz hakkın olmadığını hala öğrenemedin mi?");
                    GameManager.StartText(sentences, null);
                }
            }, answer);
            
            
            /*var sequence = DOTween.Sequence();
            sequence.InsertCallback(5f,() =>
            {
                if (answer == "yes")
                {
                    List<string> sentences = new List<string>();
                    sentences.Add("Yanlış. Doğduğun günden beri sana ait olmayan bir hayatı, nasıl sahiplenip değiştirebilirsin?");
                    GameManager.StartText(sentences, null);
                }
                else
                {
                    List<string> sentences = new List<string>();
                    sentences.Add("Bir söz hakkın olmadığını hala öğrenemedin mi?");
                    GameManager.StartText(sentences, null);
                }
            });*/
            
            
            //sequence.Play();
        }

        public override void OnExit(Action doOnExit = null)
        {
            base.OnExit(null);
        }
    }
}