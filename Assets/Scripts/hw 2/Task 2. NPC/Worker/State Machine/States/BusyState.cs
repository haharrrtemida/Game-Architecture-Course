using System;
using UnityEngine;

namespace hw2.task2
{
    public class BusyState : NPCState
    {
        protected BusyStateConfig _config;
        private Timer _timer;
        private WorkerNPC _worker;
        
        public BusyState(IStateSwitcher stateSwitcher, StateMachineData data, WorkerNPC worker) : base(stateSwitcher, data, worker)
        {
            _worker = worker;
            _config = worker.Config.BusyStateConfig;
            _timer = new Timer(_config.Time);
            _timer.OnTimerEnd += HandleTimerEnd;
        }

        protected bool IsTimeOver => _timer.RemainingSeconds <= 0f;

        public override void Enter()
        {
            base.Enter();

            _timer = new Timer(_config.Time);
            _timer.OnTimerEnd += HandleTimerEnd;

            View.StartBusy();
        }

        public override void Update()
        {
            base.Update();

            _timer.Tick(Time.deltaTime);
        }

        public override void Exit()
        {
            base.Exit();

            _timer.OnTimerEnd -= HandleTimerEnd;

            View.StopBusy();
        }

        private void HandleTimerEnd()
        {
            switch (WorkerTarget.TargetType)
            {
                case NPCTargetType.Home:
                    _worker.SetTarger(NPCTargetType.Mine);
                    break;
                case NPCTargetType.Mine:
                    _worker.SetTarger(NPCTargetType.Home);
                    break;
            }
            StateSwitcher.SwitchState<WalkingState>();
        }
    }
}