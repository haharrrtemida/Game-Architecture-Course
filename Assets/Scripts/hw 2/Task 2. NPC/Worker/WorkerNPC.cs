using UnityEngine;
using UnityEngine.AI;

namespace hw2.task2
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class WorkerNPC : MonoBehaviour
    {
        [SerializeField] private WorkerConfig _config;
        [SerializeField] private AssetHub _assetHub;
        private NavMeshAgent _agent;
        private WorkerStateMachine _stateMachine;
        private NPCTarget _target;

        public NavMeshAgent NavMeshAgent => _agent;
        public WorkerConfig Config => _config;
        public NPCTarget Target => _target;

        private void Awake()
        {
            _assetHub.Initialize();
            _agent = GetComponent<NavMeshAgent>();
            _stateMachine = new WorkerStateMachine(this);
            _target = _assetHub.NPCTargets[NPCTargetType.Home];
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        public void SetTarger(NPCTargetType targetType)
        {
            if (Target.TargetType == targetType) return;
            _target = _assetHub.NPCTargets[targetType];
        }
    }
}