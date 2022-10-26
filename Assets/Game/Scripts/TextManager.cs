using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Game.Scripts
{
    public class TextManager : MonoBehaviour
    {
        private IEnumerator _textSequence;
        public event Action TextCompleted;

        public void StartTyping(string sentence, TextMeshProUGUI text,float duration)
        {
            if(_textSequence != null)
                StopCoroutine(_textSequence);
            
            _textSequence = TypeSentence(sentence, text,duration);
            StartCoroutine(_textSequence);
        }

        private IEnumerator TypeSentence(string sentence, TextMeshProUGUI text, float duration)
        {
            var counter = 0;
            text.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                text.text += letter;
                yield return new WaitForSeconds(duration);
                counter++;
            }

            if (counter > sentence.ToCharArray().Length - 1)
            {
                yield return new WaitForSeconds(1f);
                TextCompleted?.Invoke();
            }
        }
    }
}
