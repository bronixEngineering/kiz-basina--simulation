using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class RightHandBehaviour : MonoBehaviour
    {
        [SerializeField] private ModelBehaviour _modelBehaviour;

        public event Action StartButtonInteracted;
        public event Action Name1ButtonInteracted;
        public event Action Name2ButtonInteracted;
        public event Action Name3ButtonInteracted;
        public event Action Name4ButtonInteracted;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("StartButton"))
            {
                _modelBehaviour.StartButtonInteracted();
                StartButtonInteracted?.Invoke();
            }
            
            if (other.CompareTag("Name1"))
            {
                Name1ButtonInteracted?.Invoke();
            }
            
            if (other.CompareTag("Name2"))
            {
                Name2ButtonInteracted?.Invoke();
            }
            
            if (other.CompareTag("Name3"))
            {
                Name3ButtonInteracted?.Invoke();            
            }
            
            if (other.CompareTag("Name4"))
            {
                Name4ButtonInteracted?.Invoke();            
            }
        }
    }
}
