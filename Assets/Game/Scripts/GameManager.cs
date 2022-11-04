using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private RightHandBehaviour _rightHand;
        [SerializeField] private LeftHandBehaviour _leftHand;
        [SerializeField] private TextManager _textManager;
        [SerializeField] private GameObject _startButton;
        [SerializeField] private List<GameObject> _nameButtons;
        [SerializeField] private TextMeshProUGUI _startButtonText;
        [SerializeField] private TextMeshProUGUI _mainText;
        [SerializeField] private GameObject _firstLight;
        [SerializeField] private Light _secondLight;
        

        private void Awake()
        {
            _rightHand.StartButtonInteracted += OnStartButtonInteracted;
            _leftHand.StartButtonInteracted += OnStartButtonInteracted;
            _rightHand.NameButtonInteracted += OnNameButtonActivated;
            _leftHand.NameButtonInteracted += OnNameButtonActivated;
        }

        private void OnStartButtonInteracted()
        {
            _firstLight.gameObject.SetActive(false);
            _secondLight.gameObject.SetActive(true);
            SpotLightOpen();
            
            _startButton.gameObject.SetActive(false);
            NameButtonActivate(true);
            _textManager.StartTyping("İsmin ne?",_mainText, 0.1f);
        }

        private void OnNameButtonActivated(string name)
        {
            _textManager.TextCompleted += OnTextCompleted;
            NameButtonActivate(false);
            if (name == "Name1")
            {
                List<string> sentences = new List<string>();
                sentences.Add("Bursa’nın Nilüfer ilçesinde, icra memuru bir baba ve öğretmen bir annenin ilk kız çocuğu olarak dünyaya geldin");
                sentences.Add("Annen ismin Selin olsun istedi, baban Sena olacak dedi");
                sentences.Add("Kulağına 3 kez fısıldadılar");
                sentences.Add("Hayatın, bir hastane odasının ufak küvezinde başladı");
    
                _textManager.StartTyping(sentences, _mainText, 5f);
                //_textManager.StartTyping("“Bursa’nın Nilüfer ilçesinde, icra memuru bir baba ve öğretmen bir annenin ilk kız çocuğu olarak dünyaya geldin. Annen ismin Selin olsun istedi, baban Sena olacak dedi. Kulağına 3 kez fısıldadılar.”“Hayatın, bir hastane odasının ufak küvezinde başladı.”", _mainText, 0.05f);
            }
            else if (name == "Name2")
            {
                List<string> sentences = new List<string>();
                sentences.Add("Malatya’nın Hanımağa köyünde, çiftçi bir baba ve ev hanımı bir annenin üçüncü kız çocuğu olarak dünyaya geldin");
                sentences.Add("“Bir daha kız evladın olmaz, Döndü koy, adettendir” dedi deden");
                sentences.Add("Kulağına 3 kez fısıldadılar");
                sentences.Add("Hayatın, bir köy evi odasında, ağlama sesleri ve hayal kırıklıkları ile başladı");
    
                _textManager.StartTyping(sentences, _mainText, 5f);
                //_textManager.StartTyping("“Malatya’nın Hanımağa köyünde, çiftçi bir baba ve ev hanımı bir annenin üçüncü kız çocuğu olarak dünyaya geldin. “Bir daha kız evladın olmaz, Döndü koy, adettendir” dedi deden. Kulağına 3 kez fısıldadılar.”“Hayatın, bir köy evi odasında, ağlama sesleri ve hayal kırıklıkları ile başladı.”", _mainText, 0.05f);

            }
            else if (name == "Name3")
            {
                List<string> sentences = new List<string>();
                sentences.Add("Diyarbakır Silvan’ın Akçayır köyünde, hayvancılıkla uğraşan bir baba ve ev hanımı bir annenin ilk kız çocuğu olarak dünyaya geldin");
                sentences.Add("İsmini abin koydu");
                sentences.Add("Kulağına 3 kez fısıldadılar");
                sentences.Add("Hayatın, bir köy evinin odasında, abinin kucağında başladı");
    
                _textManager.StartTyping(sentences, _mainText, 5f);
                //_textManager.StartTyping("Diyarbakır Silvan’ın Akçayır köyünde, hayvancılıkla uğraşan bir baba ve ev hanımı bir annenin ilk kız çocuğu olarak dünyaya geldin. İsmini abin koydu. Kulağına 3 kez fısıldadılar.”“Hayatın, bir köy evinin odasında, abinin kucağında başladı.”", _mainText, 0.05f);

            }
            else if (name == "Name4")
            {
                List<string> sentences = new List<string>();
                sentences.Add("Ankara’nın Çankaya ilçesinde, devlet memuru bir baba ve öğretmen bir annenin ilk kız çocuğu olarak dünyaya geldin");
                sentences.Add("Annen ismini Özgür koymak istedi, özgür olsun, bahtı açık olsun dedi");
                sentences.Add("Kulağına 3 kez fısıldadılar");
                sentences.Add("Hayatın, bir hastane odasında, annenin kucağında başladı");
    
                _textManager.StartTyping(sentences, _mainText, 5f);
                //_textManager.StartTyping("“Ankara’nın Çankaya ilçesinde, devlet memuru bir baba ve öğretmen bir annenin ilk kız çocuğu olarak dünyaya geldin. Annen ismini Özgür koymak istedi, özgür olsun, bahtı açık olsun dedi. Kulağına 3 kez fısıldadılar.”“Hayatın, bir hastane odasında, annenin kucağında başladı.”", _mainText, 0.05f);

            }
        }

        private void OnTextCompleted()
        {
            _textManager.TextCompleted -= OnTextCompleted;
            _startButton.gameObject.SetActive(true);
            _textManager.StartTyping("Yeniden Başlat", _startButtonText, .02f);
        }

        private void NameButtonScale(bool bl)
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

        private void NameButtonActivate(bool bl)
        {
            foreach (var button in _nameButtons)
            {
                button.gameObject.SetActive(bl);
                NameButtonScale(bl);
            }
        }

        private void SpotLightOpen()
        {
            StartCoroutine(SpotLigthOpenRoutine());
        }

        private IEnumerator SpotLigthOpenRoutine()
        {
            float _currentIntensityValue = 0;
            _secondLight.intensity = _currentIntensityValue;

            while (_currentIntensityValue <= 2)
            {
                _currentIntensityValue += Time.deltaTime/2f;
                _secondLight.intensity = _currentIntensityValue;
                yield return null;
            }
        }


        private void OnDestroy()
        {
            _rightHand.StartButtonInteracted -= OnStartButtonInteracted;
            _rightHand.NameButtonInteracted -= OnNameButtonActivated;
            _leftHand.NameButtonInteracted -= OnNameButtonActivated;
            _leftHand.StartButtonInteracted -= OnStartButtonInteracted;


        }
    }
    
}
