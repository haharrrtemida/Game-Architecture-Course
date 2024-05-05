using System;
using UnityEngine;

namespace hw2.task4.Mediator
{
    public abstract class Stat
    {
        public event Action OnStatValueChanged;
        private float _value;
        private float _minValue;
        private float _maxValue;

        public Stat(float minValue, float maxValue, bool startFromMin)
        {
            _minValue = minValue;
            _maxValue = maxValue;

            _value = startFromMin ? _minValue : _maxValue;
        }


        public float Value
        {
            get => _value;
            protected set
            {
                if (value < _minValue || value > _maxValue)
                    throw new ArgumentOutOfRangeException($"Incorrect data transmitted {(nameof(value))}");
                
                _value = value;
                OnStatValueChanged?.Invoke();                    
            }
        } 
        public float MinValue => _minValue;
        public float MaxValue => _maxValue;
        public float Ratio => _value / _maxValue;

        public abstract void Reset();
        public virtual void Increase(float value)
        {
            if (value < 0) throw new ArgumentException("Value for change cannot be negative");
            
            float result = _value + value;
            _value = Mathf.Min(result, _maxValue);

            OnStatValueChanged?.Invoke();
        }

        public virtual void Decrease(float value)
        {
            if (value < 0) throw new ArgumentException("Value for change cannot be negative");
            
            float result = _value - value;
            _value = Mathf.Max(result, _minValue);
            
            OnStatValueChanged?.Invoke();
        }
    }
}
