namespace hw2.task2
{
    public class RestingState : BusyState
    {
        public RestingState(IStateSwitcher stateSwitcher, StateMachineData data, WorkerNPC worker) : base(stateSwitcher, data, worker)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Data.Speed = 0;
        }
    }
}