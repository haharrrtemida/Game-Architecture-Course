using UnityEngine;
using UnityEngine.UI;

namespace hw2.task4.Mediator
{
    public class StatBarView : MonoBehaviour
    {
        [SerializeField] private Image _bar;
        private Stat _trackableStat;

        public void Initialize(Stat stat)
        {
            _trackableStat = stat;

            _trackableStat.OnStatValueChanged += UpdateView;
            UpdateView();
        }

        private void UpdateView()
        {
            _bar.fillAmount = _trackableStat.Ratio;
        }
    }
}