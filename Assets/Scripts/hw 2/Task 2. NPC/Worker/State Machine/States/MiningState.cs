namespace hw2.task2.NPC
{
    public class MiningState : BusyState
    {
        public MiningState(IStateSwitcher stateSwitcher, StateMachineData data, WorkerNPC worker) : base(stateSwitcher, data, worker)
        {
        }

        public override void Enter()
        {
            base.Enter();

            View.StartMining();
        }

        public override void Exit()
        {
            base.Exit();

            View.StopMining();
        }
    }
}