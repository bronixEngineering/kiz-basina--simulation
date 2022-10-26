using System.Collections;
using TMPro;
using UnityEngine;

namespace Game.Scripts
{
    public class TextManager : MonoBehaviour
    {
        private IEnumerator _textSequence;

        public void StartTyping(string sentence, TextMeshProUGUI text)
        {
            if(_textSequence != null)
                StopCoroutine(_textSequence);
            
            _textSequence = TypeSentence(sentence, text);
            StartCoroutine(_textSequence);
        }

        private IEnumerator TypeSentence(string sentence, TextMeshProUGUI text)
        {
            text.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                text.text += letter;
                yield return new WaitForSeconds(.05f);
            }
        }
    }
}
