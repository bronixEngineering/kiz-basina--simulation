using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using DG.Tweening;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace Game.Scripts
{
    public class TextManager : MonoBehaviour
    {
        private IEnumerator _textSequence;

        public void StartTyping(string sentence, TextMeshProUGUI text,float duration)
        {
            if(_textSequence != null)
                StopCoroutine(_textSequence);
            
            _textSequence = TypeSentence(sentence, text,duration);
            StartCoroutine(_textSequence);
        }
        
        public void StartTyping(List<string> sentences, TextMeshProUGUI text,float duration, [CanBeNull] Action completeAction)
        {
            if(_textSequence != null)
                StopCoroutine(_textSequence);
            
            _textSequence = TypeSentence(sentences, text,duration, completeAction);
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
            }
        }

        private IEnumerator TypeSentence(List<string> sentences, TextMeshProUGUI text, float duration, [CanBeNull] Action completeAction)
        {
            for (int i = 0; i <= sentences.Count - 1; i++)
            {
                var color = text.color;
                color.a = 0f;
                text.color = color;

                color.a = 1f;
                text.text = sentences[i];
                text.DOColor(color, duration / 2f);
                
                yield return new WaitForSeconds(duration);
                
                color.a = 0f;
                text.DOColor(color, duration/2f);
                
                yield return new WaitForSeconds(duration/2f);

                if (i >= sentences.Count - 1)
                {
                    completeAction?.Invoke();
                }
            }
        }
    }
}
