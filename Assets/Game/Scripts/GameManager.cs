using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Game.Scripts.StateMachine;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SoundController _soundController;
        [SerializeField] private VideoController _videoController;
        [SerializeField] private RightHandBehaviour _rightHand;
        [SerializeField] private LeftHandBehaviour _leftHand;
        [SerializeField] private TextManager _textManager;
        [SerializeField] private GameObject _startButton;
        [SerializeField] private List<GameObject> _nameButtons;
        [SerializeField] private List<GameObject> _decisionButtons;
        [SerializeField] private List<GameObject> _secondDecisionButtons;
        [SerializeField] private TextMeshProUGUI _startButtonText;
        [SerializeField] private TextMeshProUGUI _mainText;
        [SerializeField] private GameObject _firstLight;
        [SerializeField] private Light _secondLight;
        
        protected Dictionary<StateMachineBase.States, StateMachineBase> States;        
        protected StateMachineBase CurrentState;
        
        private void Awake()
        {
            _rightHand.StartButtonInteracted += OnStartButtonInteracted;
            _leftHand.StartButtonInteracted += OnStartButtonInteracted;
            _rightHand.NameButtonInteracted += OnNameButtonActivated;
            _leftHand.NameButtonInteracted += OnNameButtonActivated;
            _rightHand.DecisionButtonInteracted += OnDecisionButtonInteracted;
            _leftHand.DecisionButtonInteracted += OnDecisionButtonInteracted;
            _rightHand.SecondDecisionButtonInteracted += OnSecondDecisionButtonInteracted;
            _leftHand.SecondDecisionButtonInteracted += OnSecondDecisionButtonInteracted;
        }

        private void Start()
        {
            
            States = new Dictionary<StateMachineBase.States, StateMachineBase>()
            {
                {StateMachineBase.States.Default, new DefaultStageBehaviour(this, _soundController, _videoController)},
                {StateMachineBase.States.Stage1, new Stage1Behaviour(this, _soundController, _videoController)},
                {StateMachineBase.States.Stage2, new Stage2Behaviour(this, _soundController, _videoController)},
                {StateMachineBase.States.Stage3, new Stage3Behaviour(this, _soundController, _videoController)},
                {StateMachineBase.States.Stage4, new Stage4Behaviour(this, _soundController, _videoController)},
                {StateMachineBase.States.Stage5, new Stage5Behaviour(this, _soundController, _videoController)},
                {StateMachineBase.States.Stage6, new Stage6Behaviour(this, _soundController, _videoController)},
            };
            
            ChangeStateTo(StateMachineBase.States.Default);
        
        }

        public void ChangeStateTo(StateMachineBase.States requestedState)
        {
            CurrentState?.OnExit();
            var nextState = CurrentState is null ? StateMachineBase.States.Default : requestedState;
            CurrentState = States[nextState];
            CurrentState.OnEnter();
        }

        private void OnStartButtonInteracted()
        {
            ChangeStateTo(StateMachineBase.States.Default);
            _firstLight.gameObject.SetActive(false);
            _secondLight.gameObject.SetActive(true);
            _startButton.gameObject.SetActive(false);
            NameButtonActivate(true);
            _textManager.StartTyping("İsmin ne?",_mainText, 0.1f);
        }

        private void OnNameButtonActivated()
        {
            NameButtonActivate(false);
            ChangeStateTo(StateMachineBase.States.Stage1);
        }

        public void OnDecisionButtonInteracted(string answer)
        {
            
            ChangeStateTo(StateMachineBase.States.Stage4);

        }

        private void OnSecondDecisionButtonInteracted(string answer)
        { 
            SecondDecisionButtonActivate(false, null, answer);
            ChangeStateTo(StateMachineBase.States.Stage6);
        }

        public void StartText(List<string> sentences, [CanBeNull] Action completeAction)
        {
            _textManager.StartTyping(sentences, _mainText, 3.5f, completeAction);
        }

        private void NameButtonActivate(bool bl)
        {
            foreach (var button in _nameButtons)
            {
                button.gameObject.SetActive(bl);
                
                if (bl)
                {
                    button.transform.DOScale(Vector3.one, 2f);
                }
                else
                {
                    button.transform.DOScale(Vector3.zero, 2f);
                }
            }
        }

        public void DecisionButtonActivate(bool bl, [CanBeNull] Action completeAction, [CanBeNull] string answer)
        {
            foreach (var button in _decisionButtons)
            {
                button.gameObject.SetActive(bl);
            }

            if (!bl)
            {
                completeAction?.Invoke();
            }
        }
        public void SecondDecisionButtonActivate(bool bl, [CanBeNull] Action completeAction, [CanBeNull] string answer)
        {
            foreach (var button in _secondDecisionButtons)
            {
                button.gameObject.SetActive(bl);
            }

            if (!bl)
            {
                completeAction?.Invoke();
            }
        }

        public void SpotLightOpen(bool open)
        {
            StartCoroutine(SpotLightOpenRoutine(open));
        }

        private IEnumerator SpotLightOpenRoutine(bool open)
        {
            if (open)
            {
                float _currentIntensityValue = 0;
                _secondLight.intensity = _currentIntensityValue;

                while (_currentIntensityValue <= 2)
                {
                    _currentIntensityValue += Time.deltaTime;
                    _secondLight.intensity = _currentIntensityValue;
                    yield return null;
                }
            }
            else
            {
                while (_secondLight.intensity >= 0)
                {
                    _secondLight.intensity -= Time.deltaTime;
                    yield return null;
                }
            }
        }


        private void OnDestroy()
        {
            _rightHand.StartButtonInteracted -= OnStartButtonInteracted;
            _rightHand.NameButtonInteracted -= OnNameButtonActivated;
            _leftHand.NameButtonInteracted -= OnNameButtonActivated;
            _leftHand.StartButtonInteracted -= OnStartButtonInteracted;
            _rightHand.DecisionButtonInteracted -= OnDecisionButtonInteracted;
            _leftHand.DecisionButtonInteracted -= OnDecisionButtonInteracted;
            _rightHand.SecondDecisionButtonInteracted -= OnSecondDecisionButtonInteracted;
            _leftHand.SecondDecisionButtonInteracted -= OnSecondDecisionButtonInteracted;
        }
    }
    
}
