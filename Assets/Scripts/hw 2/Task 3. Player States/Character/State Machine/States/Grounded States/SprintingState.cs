namespace hw2.task3
{
    public class SprintingState : GroundedState
    {
        private readonly SprintStateConfig _config;
        public SprintingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            _config = character.Config.SprintStateConfig;
        }

        public override void Enter()
        {
            base.Enter();

            Data.Speed = _config.Speed;

            View.StartSprinting();
        }

        public override void Exit()
        {
            base.Exit();

            View.StopSprinting();
        }

        public override void Update()
        {
            base.Update();

            if (IsHorizontalInputZero())
                StateSwitcher.SwitchState<IdlingState>();
        }
    }
}