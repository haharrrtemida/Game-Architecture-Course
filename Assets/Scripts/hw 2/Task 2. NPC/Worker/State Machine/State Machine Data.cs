using System;

namespace hw2.task2.NPC
{  
    public class StateMachineData
    {
        private float _time;

        public float Time
        {
            get => _time;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                
                _time = value;
            }
        }
    }
}