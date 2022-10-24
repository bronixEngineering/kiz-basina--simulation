using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class RightHandBehaviour : MonoBehaviour
    {
        [SerializeField] private ModelBehaviour _modelBehaviour;

        public event Action StartButtonInteracted;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("StartButton"))
            {
                _modelBehaviour.StartButtonInteracted();
                StartButtonInteracted?.Invoke();
            }
            
            if (other.CompareTag("StartButton"))
            {
                _modelBehaviour.StartButtonInteracted();
            }
            
            if (other.CompareTag("StartButton"))
            {
                _modelBehaviour.StartButtonInteracted();
            }
            
            if (other.CompareTag("StartButton"))
            {
                _modelBehaviour.StartButtonInteracted();
            }
        }
    }
}
