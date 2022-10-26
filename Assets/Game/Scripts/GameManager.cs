using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private RightHandBehaviour _rightHand;
        [SerializeField] private ModelBehaviour _model;
        [SerializeField] private TextManager _textManager;
        [SerializeField] private GameObject _startButton;
        [SerializeField] private List<GameObject> _nameButtons;
        [SerializeField] private TextMeshProUGUI _mainText;

        private void Awake()
        {
            _rightHand.StartButtonInteracted += OnStartButtonInteracted;
            _rightHand.Name1ButtonInteracted += OnName1ButtonActivated;
            _rightHand.Name2ButtonInteracted += OnName2ButtonActivated;
            _rightHand.Name3ButtonInteracted += OnName3ButtonActivated;
            _rightHand.Name4ButtonInteracted += OnName4ButtonActivated;
        }

        private void OnStartButtonInteracted()
        {
            _startButton.gameObject.SetActive(false);
            NameButtonActivate(true);
            _mainText.text = "İsmin ne?";
            _mainText.transform.parent.transform.DOScale(Vector3.one*0.6f, 4f);
        }

        private void OnName1ButtonActivated()
        {
            NameButtonActivate(false);
            _textManager.StartTyping("Sena", _mainText);
        }
        
        private void OnName2ButtonActivated()
        {
            NameButtonActivate(false);
            _textManager.StartTyping("Döndü", _mainText);
        }
        
        private void OnName3ButtonActivated()
        {
            NameButtonActivate(false);
            _textManager.StartTyping("Melike", _mainText);
        }
        
        private void OnName4ButtonActivated()
        {
            NameButtonActivate(false);
            _textManager.StartTyping("Özgür", _mainText);
        }

        private void NameButtonActivate(bool bl)
        {
            foreach (var button in _nameButtons)
            {
                if (bl)
                {               
                    button.transform.DOScale(Vector3.one*0.4f, 4f);
                }
                else
                {
                    button.transform.DOScale(Vector3.zero, 1f);

                }
            }
        }

        private void OnDestroy()
        {
            _rightHand.StartButtonInteracted -= OnStartButtonInteracted;
            _rightHand.Name1ButtonInteracted -= OnName1ButtonActivated;
            _rightHand.Name2ButtonInteracted -= OnName2ButtonActivated;
            _rightHand.Name3ButtonInteracted -= OnName3ButtonActivated;
            _rightHand.Name4ButtonInteracted -= OnName4ButtonActivated;
        }
    }
    
}
