using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Scripts.StateMachine
{
    public abstract class StateMachineBase
    {

        protected readonly GameManager GameManager;
        protected readonly SoundController SoundController;
        protected readonly VideoController VideoController;
        
        public enum States
        {
            Default,
            Stage1,
            Stage2,
            Stage3,
            Stage4,
            Stage5,
            Stage6,
            Stage7
        }
        
        protected StateMachineBase(GameManager gameManager, SoundController soundController, VideoController videoController)
        {
            GameManager = gameManager;
            SoundController = soundController;
            VideoController = videoController;
        }
        
        public virtual void OnEnter(Action doOnEnter = null, string answer = null)
        {
        }

        public virtual void OnExit(Action doOnExit = null)
        {
          //  VideoController.StopVideo();
          //  SoundController.StopSound();
        }
    }
}
