using UnityEngine;

namespace Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private RightHandBehaviour _rightHand;
        [SerializeField] private ModelBehaviour _model;

        [SerializeField] private GameObject _startButton;

        private void Awake()
        {
            _rightHand.StartButtonInteracted += OnStartButtonInteracted;
        }

        private void OnStartButtonInteracted()
        {
            _startButton.gameObject.SetActive(false);
        }
    }
}
