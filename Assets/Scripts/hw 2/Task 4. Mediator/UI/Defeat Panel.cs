using System;
using UnityEngine;
using UnityEngine.UI;

namespace hw2.task4.Mediator
{
    public class DefeatPanel : MonoBehaviour
    {
        public event Action OnRestartButtonClick;
        [SerializeField] private Button _restartButton;
        
        private void OnEnable()
        {
            _restartButton.onClick.AddListener(RestartButtonClick);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(RestartButtonClick);
        }

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
        
        private void RestartButtonClick()
        {
            OnRestartButtonClick?.Invoke();
            Hide();
        }
    }
}