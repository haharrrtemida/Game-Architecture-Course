using System;

namespace hw3.task2
{
    public class Timer
    {
        public event Action OnTimerEnd;
        private float _ramainingSeconds;
        private float _countingTime;
        
        public Timer(float duration)
        {
            RemainingSeconds = duration;
            _countingTime = duration;
        }

        public float RemainingSeconds
        {
            get => _ramainingSeconds;
            set
            {
                if (value <= 0f)
                    throw new ArgumentException(nameof(value));
                _ramainingSeconds = value;
            }
        }

        public void Tick(float deltaTime)
        {
            if (RemainingSeconds == 0f)
                return;
            
            _ramainingSeconds -= deltaTime;
            CheckForTimerEnd();
        }

        public void Reset()
        {
            RemainingSeconds = _countingTime;
        }

        private void CheckForTimerEnd()
        {
            if (RemainingSeconds > 0f) 
                return;
            
            _ramainingSeconds = 0f;
            OnTimerEnd?.Invoke();
        }
    }   
}