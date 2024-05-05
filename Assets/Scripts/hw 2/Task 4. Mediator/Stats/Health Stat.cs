using System;

namespace hw2.task4.Mediator
{
    public class HealthStat : Stat
    {
        public event Action OnMinValueAchieve;
        public HealthStat(float minValue, float maxValue) : base(minValue, maxValue, false) { }

        public override void Decrease(float value)
        {
            base.Decrease(value);

            if (Ratio == 0) OnMinValueAchieve?.Invoke();
        }

        public override void Reset()
        {
            Value = MaxValue;
        }
    }
}