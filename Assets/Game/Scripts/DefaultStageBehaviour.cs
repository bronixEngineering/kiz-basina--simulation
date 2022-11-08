using System;
using Game.Scripts.StateMachine;

namespace Game.Scripts
{
    public class DefaultStageBehaviour : StateMachineBase
    {
        public DefaultStageBehaviour(GameManager gameManager, SoundController soundController, VideoController videoController) : base(gameManager, soundController, videoController)
        {
        }
        
        public virtual void OnEnter(Action doOnEnter = null)
        {
        }

        public virtual void OnExit(Action doOnExit = null)
        {
        }
    }
}
