using System;

namespace hw2.task4.Mediator
{
    public class ExperienceStat : Stat
    {
        public event Action OnMaxValueAchieve;
        public ExperienceStat(float minValue, float maxValue) : base(minValue, maxValue, true) { }

        public override void Increase(float value)
        {
            base.Increase(value);
            
            if (Ratio == 1) OnMaxValueAchieve?.Invoke();
        }

        public override void Reset()
        {
            Value = MinValue;
        }
    }
}