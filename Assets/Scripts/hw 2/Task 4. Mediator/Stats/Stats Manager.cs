using System.Collections.Generic;
using UnityEngine;

namespace hw2.task4.Mediator
{
    
    public class StatsManager : MonoBehaviour
    {
        [SerializeField] private PlayerStatsConfig _statConfig;
        private ExperienceStat _experience;
        private HealthStat _health;
        private Dictionary<StatType, Stat> _allStats;

        public Dictionary<StatType, Stat> Stats => _allStats;


        public void Initialize()
        {
            _experience = new ExperienceStat(
                minValue: _statConfig.MinExperiencePoints,
                maxValue: _statConfig.MaxExperiencePoints
            );

            _health = new HealthStat(
                minValue: _statConfig.MinHealthPoints,
                maxValue: _statConfig.MaxHealthPoints
            );

            _allStats = new Dictionary<StatType, Stat>()
            {
                {StatType.Experience, _experience},
                {StatType.Health, _health}
            };
        }

        public void LevelUp()
        {
            _experience.Reset();
        }

        public void ResetAllStats()
        {
            foreach(var stat in _allStats.Values)
            {
                stat.Reset();
            }
        }
    }
}