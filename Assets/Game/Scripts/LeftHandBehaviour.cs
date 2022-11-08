using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class LeftHandBehaviour : MonoBehaviour
    {
        [SerializeField] private ModelBehaviour _modelBehaviour;
        [SerializeField] private GameObject _selectionImage; 
        [SerializeField] private Image _fillImage;
        [SerializeField] private GameManager _gameManager;

        private IEnumerator FillRoutine;
        private float _selectionTime = 6f;
        private float _currentFillValue;

        public event Action StartButtonInteracted;
        public event Action NameButtonInteracted;
        public event Action<string> DecisionButtonInteracted;
        public event Action<string> SecondDecisionButtonInteracted;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("StartButton"))
            {
                StartFillImageRoutine( false, true,false,false, null);
            }
            
            if (other.CompareTag("Name"))
            {
                StartFillImageRoutine(true, false,false,false, null);
            }
            
            if (other.CompareTag("Yes"))
            { 
                StartFillImageRoutine(false, false, true,false, "yes");
            }
            if (other.CompareTag("No"))
            { 
                StartFillImageRoutine(false, false,true,false, "no");
            }
            if (other.CompareTag("Yess"))
            { 
                StartFillImageRoutine(false, false,false,true,  "yes");
            }
            if (other.CompareTag("Noo"))
            { 
                StartFillImageRoutine(false, false,false, true, "no");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            StopCoroutine(FillRoutine);
            _selectionImage.SetActive(false);
        }

        private void StartFillImageRoutine(bool nameButton, bool startButton, bool decisionButton, bool secondDecisionButton, [CanBeNull] string answer)
        {
            _selectionImage.SetActive(true);
            if (FillRoutine != null)
            {
                StopCoroutine(FillRoutine);
            }

            FillRoutine = FillImageRoutine(nameButton, startButton,decisionButton,secondDecisionButton, answer);
            StartCoroutine(FillRoutine);
        }

        private IEnumerator FillImageRoutine(bool nameButton, bool startButton, bool decisionButton, bool secondDecisionButton, [CanBeNull] string answer)
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
                NameButtonInteracted?.Invoke();    
            }
            else if (startButton)
            {
                StartButtonInteracted?.Invoke();
                _modelBehaviour.StartButtonInteracted();
            }
            else if (decisionButton)
            {
                _gameManager.DecisionButtonActivate(false, null, answer);
                
                DecisionButtonInteracted?.Invoke(answer);
                

            }
            else if (secondDecisionButton)
            {
                _gameManager.SecondDecisionButtonActivate(false, null, answer);
                SecondDecisionButtonInteracted?.Invoke(answer);

            }
            
            _selectionImage.SetActive(false);
            
        }
    }
}
