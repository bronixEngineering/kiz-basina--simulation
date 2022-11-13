using System;
using System.Collections.Generic;
using DG.Tweening;

namespace Game.Scripts.StateMachine
{
    public class Stage7Behaviour : StateMachineBase
    {
        public Stage7Behaviour(GameManager gameManager, SoundController soundController, VideoController videoController) : base(gameManager, soundController, videoController)
        {
        }
        
        public override void OnEnter(Action doOnEnter = null, string answer = null)
        {
            base.OnEnter(null);
            List<string> sentences = new List<string>();

            sentences.Add(
                "Bu deneyim, Türkiye’de kadınların maruz bırakıldığı eşitsizlik ve şiddet gerçeği konusunda farkındalık yaratmak ve empati seviyesini yükseltmek amacıyla UNFPA işbirliği ile gerçekleştirilmiştir.");
          
            sentences.Add("Katılımınız için teşekkür ederiz.");
            sentences.Add("Deneyime katkılarından dolayı Ankara Büyükşehir Belediyesi’ne, Bronix Engineering Solutions’a, Ömer Faruk Önder'e, Resul Ercan'a ve Ankara Aks’a çok teşekkür ederiz.");

            GameManager.StartText(sentences, 7f,null);
        }

        public override void OnExit(Action doOnExit = null)
        {
            base.OnExit(null);
        }
    }
}