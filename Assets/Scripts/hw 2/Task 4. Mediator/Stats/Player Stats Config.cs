using UnityEngine;

namespace hw2.task4.Mediator
{
    
    [CreateAssetMenu(fileName = "Player Stats Config", menuName = "Configs/PlayerStatsConfig", order = 0)]
    public class PlayerStatsConfig : ScriptableObject
    {
        [field: SerializeField, Range(0, 100)] public float MinExperiencePoints { get; private set; }
        [field: SerializeField, Range(0, 100)] public float MaxExperiencePoints { get; private set; }
        [field: SerializeField, Range(0, 100)] public float MinHealthPoints { get; private set; }
        [field: SerializeField, Range(0, 100)] public float MaxHealthPoints { get; private set; }
    }
}