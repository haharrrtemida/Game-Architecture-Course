using UnityEngine;

namespace hw2.task2.NPC
{
    [CreateAssetMenu(fileName = "WorkerConfig", menuName = "Configs/WorkerConfig")]
    public class WorkerConfig : ScriptableObject
    {
        [SerializeField] private WalkingStateConfig _walkingStateConfig;
        [SerializeField] private BusyStateConfig _busyStateConfig;

        public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
        public BusyStateConfig BusyStateConfig => _busyStateConfig;
    }
}