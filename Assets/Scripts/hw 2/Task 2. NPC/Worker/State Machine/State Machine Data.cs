using System;

namespace hw2.task2
{  
    public class StateMachineData
    {
        private float _speed;
        private float _time;

        public float Speed
        {
            get => _speed;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                
                _speed = value;
            }
        }

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