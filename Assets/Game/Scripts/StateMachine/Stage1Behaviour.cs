using System;
using System.Collections.Generic;

namespace Game.Scripts.StateMachine
{
    public class Stage1Behaviour : StateMachineBase
    {
        public Stage1Behaviour(GameManager gameManager, SoundController soundController, VideoController videoController) : base(gameManager, soundController, videoController)
        {
        }
        
        public override void OnEnter(Action doOnEnter = null, string answer = null)
        {
            base.OnEnter(null);
            SoundController.PlayCrowdSound();
            List<string> sentences = new List<string>();
            
            sentences.Add("Yanlış. İsmini ve kaderini seçebileceğini sana kim düşündürdü?");
            sentences.Add("Diyarbakır Silvan’ın Akçayır köyünde, hayvancılıkla uğraşan bir baba ve ev hanımı bir annenin üçüncü kız çocuğu olarak dünyaya geldin");
            sentences.Add("“Bir daha kız evladın olmaz, Döndü koy, adettendir” dedi deden");
            sentences.Add("Kulağına 3 kez fısıldadılar");
            sentences.Add("Hayatın, bir köy evi odasında, ağlama sesleri ve hayal kırıklıkları ile başladı");
            
            GameManager.StartText(sentences,3.5f ,() =>
            {
                GameManager.ChangeStateTo(States.Stage2, null);
            });
        }

        public override void OnExit(Action doOnExit = null)
        {
            
            base.OnExit(null);
        }
    }
}
