namespace hw2.task2
{
    public class MiningState : BusyState
    {
        public MiningState(IStateSwitcher stateSwitcher, StateMachineData data, WorkerNPC worker) : base(stateSwitcher, data, worker)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Data.Speed = 0;
        }
    }
}