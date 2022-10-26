using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class RightHandBehaviour : MonoBehaviour
    {
        [SerializeField] private ModelBehaviour _modelBehaviour;

        public event Action StartButtonInteracted;
        public event Action<string> NameButtonInteracted;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("StartButton"))
            {
                _modelBehaviour.StartButtonInteracted();
                StartButtonInteracted?.Invoke();
            }
            
            if (other.CompareTag("Name1"))
            {
                NameButtonInteracted?.Invoke("Name1");
            }
            
            if (other.CompareTag("Name2"))
            {
                NameButtonInteracted?.Invoke("Name2");
            }
            
            if (other.CompareTag("Name3"))
            {
                NameButtonInteracted?.Invoke("Name3");            
            }
            
            if (other.CompareTag("Name4"))
            {
                NameButtonInteracted?.Invoke("Name2");            
            }
        }
    }
}
