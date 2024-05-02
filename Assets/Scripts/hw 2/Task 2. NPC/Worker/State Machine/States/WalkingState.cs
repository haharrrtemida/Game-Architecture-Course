using UnityEngine;

namespace hw2.task2
{
    public class WalkingState : NPCState
    {
        private readonly WalkingStateConfig _config;

        public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, WorkerNPC worker) : base(stateSwitcher, data, worker)
        {
            _config = worker.Config.WalkingStateConfig;
        }

        public override void Enter()
        {
            base.Enter();

            Data.Speed = _config.Speed;

            Agent.SetDestination(WorkerTarget.Position);

            // View.StartRunning();
        }

        public override void Exit()
        {
            base.Exit();
            
            // View.StopRunning();
        }

        public override void Update()
        {
            base.Update();

            if (IsTargetReached())
            {
                switch (WorkerTarget.TargetType)
                {
                    case NPCTargetType.Home:
                        StateSwitcher.SwitchState<RestingState>();
                        break;
                    case NPCTargetType.Mine:
                        StateSwitcher.SwitchState<MiningState>();
                        break;
                }
            }
        }

        private bool IsTargetReached() => Vector3.Distance(WorkerPosition, WorkerTarget.Position) <= _config.StopingDistance;
    }
}