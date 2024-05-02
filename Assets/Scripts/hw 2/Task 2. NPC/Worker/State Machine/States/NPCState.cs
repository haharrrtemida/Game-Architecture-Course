using UnityEngine;

namespace hw2.task2
{
    public abstract class NPCState : INPCState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly StateMachineData Data;
        private readonly WorkerNPC _worker;
        
        public NPCState(IStateSwitcher stateSwitcher, StateMachineData data, WorkerNPC worker)
        {
            StateSwitcher = stateSwitcher;
            Data = data;
            _worker = worker;
        }

        protected Vector3 WorkerPosition => _worker.transform.position;
        protected NPCTarget WorkerTarget => _worker.Target;
        protected UnityEngine.AI.NavMeshAgent Agent => _worker.NavMeshAgent;

        public virtual void Enter()
        {
            Debug.Log(GetType());
        }

        public virtual void Exit() { }

        public virtual void Update() { }
    }
}