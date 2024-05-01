using UnityEngine;

namespace hw2.task3
{  
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private WalkingStateConfig _walkingStateConfig;
        [SerializeField] private RunningStateConfig _runningStateConfig;
        [SerializeField] private SprintStateConfig _sprintStateConfig;
        [SerializeField] private AirborneStateConfig _airborneStateConfig;

        public RunningStateConfig RunningStateConfig => _runningStateConfig;
        public AirborneStateConfig AirborneStateConfig => _airborneStateConfig;
        public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
        public SprintStateConfig SprintStateConfig => _sprintStateConfig;
    }
}