using UnityEngine;

namespace hw2.task4.Mediator
{
    public class StatsMediator : MonoBehaviour
    {
        [SerializeField] private StatBarView _experienceBar;
        [SerializeField] private StatBarView _healthBar;
        [SerializeField] private DefeatPanel _defeatPanel;
        private StatsManager _playerStatManager;

        private ExperienceStat Experience => _playerStatManager.Stats[StatType.Experience] as ExperienceStat;
        private HealthStat Health => _playerStatManager.Stats[StatType.Health] as HealthStat;

        
        public void Initialize(StatsManager playerStatManager)
        {
            _playerStatManager = playerStatManager;
            Experience.OnMaxValueAchieve += LevelUp;
            Health.OnMinValueAchieve += ShowDefeatPanel;

            _experienceBar.Initialize(Experience);
            _healthBar.Initialize(Health);
            _defeatPanel.OnRestartButtonClick += _playerStatManager.ResetAllStats;
            _defeatPanel.Hide();
        }

        private void LevelUp() => _playerStatManager.LevelUp();
        private void ShowDefeatPanel() => _defeatPanel.Show();
    }
}