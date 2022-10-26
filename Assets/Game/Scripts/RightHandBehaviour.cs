using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class RightHandBehaviour : MonoBehaviour
    {
        [SerializeField] private ModelBehaviour _modelBehaviour;
        [SerializeField] private GameObject _selectionImage; 
        [SerializeField] private Image _fillImage;

        private IEnumerator FillRoutine;
        private float _selectionTime = 6f;
        private float _currentFillValue;

        public event Action StartButtonInteracted;
        public event Action<string> NameButtonInteracted;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("StartButton"))
            {
                StartFillImageRoutine( null, false);
            }

            if (other.CompareTag("Name1"))
            {
                StartFillImageRoutine("Name1", true);
            }

            if (other.CompareTag("Name2"))
            {
                StartFillImageRoutine("Name2", true);
            }

            if (other.CompareTag("Name3"))
            {
                StartFillImageRoutine("Name3", true);
            }

            if (other.CompareTag("Name4"))
            {
                StartFillImageRoutine("Name4", true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            StopCoroutine(FillRoutine);
            _selectionImage.SetActive(false);
        }

        private void StartFillImageRoutine(string name, bool nameButton)
        {
            _selectionImage.SetActive(true);
            if (FillRoutine != null)
            {
                StopCoroutine(FillRoutine);
            }

            FillRoutine = FillImageRoutine(name, nameButton);
            StartCoroutine(FillRoutine);
        }

        private IEnumerator FillImageRoutine([CanBeNull] string name, bool nameButton)
        {
            float _currentFillValue = 0;
            _fillImage.fillAmount = _currentFillValue;

            while (_currentFillValue <= 1)
            {
                _currentFillValue += Time.deltaTime;
                _fillImage.fillAmount = _currentFillValue;
                yield return null;
            }

            if (nameButton)
            {
                NameButtonInteracted?.Invoke(name);    
            }
            else
            {
                StartButtonInteracted?.Invoke();
                _modelBehaviour.StartButtonInteracted();
            }
            
            _selectionImage.SetActive(false);
            
        }
    }
}
