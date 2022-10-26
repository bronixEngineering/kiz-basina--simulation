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
            _textManager.StartTyping("“Bursa’nın Nilüfer ilçesinde, icra memuru bir baba ve öğretmen bir annenin ilk kız çocuğu olarak dünyaya geldin. Annen ismin Selin olsun istedi, baban Sena olacak dedi. Kulağına 3 kez fısıldadılar.”“Hayatın, bir hastane odasının ufak küvezinde başladı.”", _mainText);
        }
        
        private void OnName2ButtonActivated()
        {
            NameButtonActivate(false);
            _textManager.StartTyping("“Malatya’nın Hanımağa köyünde, çiftçi bir baba ve ev hanımı bir annenin üçüncü kız çocuğu olarak dünyaya geldin. “Bir daha kız evladın olmaz, Döndü koy, adettendir” dedi deden. Kulağına 3 kez fısıldadılar.”“Hayatın, bir köy evi odasında, ağlama sesleri ve hayal kırıklıkları ile başladı.”", _mainText);
        }
        
        private void OnName3ButtonActivated()
        {
            NameButtonActivate(false);
            _textManager.StartTyping("Diyarbakır Silvan’ın Akçayır köyünde, hayvancılıkla uğraşan bir baba ve ev hanımı bir annenin ilk kız çocuğu olarak dünyaya geldin. İsmini abin koydu. Kulağına 3 kez fısıldadılar.”“Hayatın, bir köy evinin odasında, abinin kucağında başladı.”", _mainText);
        }
        
        private void OnName4ButtonActivated()
        {
            NameButtonActivate(false);
            _textManager.StartTyping("“Ankara’nın Çankaya ilçesinde, devlet memuru bir baba ve öğretmen bir annenin ilk kız çocuğu olarak dünyaya geldin. Annen ismini Özgür koymak istedi, özgür olsun, bahtı açık olsun dedi. Kulağına 3 kez fısıldadılar.”“Hayatın, bir hastane odasında, annenin kucağında başladı.”", _mainText);
        }

        private void NameButtonActivate(bool bl)
        {
            foreach (var button in _nameButtons)
            {
                var text = button.GetComponentInChildren<TextMeshProUGUI>();
                var color = text.color;
                color.a = 1;
                    
                if (bl)
                {               
                    button.transform.DOScale(Vector3.one*0.4f, 2f).OnComplete(() =>
                    {
                        text.DOColor(color, 2f);
                    });
                }
                else
                {
                    button.transform.DOScale(Vector3.zero, 2f);
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
