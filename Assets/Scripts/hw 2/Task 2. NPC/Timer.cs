using System;

namespace hw2.task2.NPC
{
    public class Timer
    {
        public event Action OnTimerEnd;
        private float _ramainingSeconds;
        
        public Timer(float duration)
        {
            RemainingSeconds = duration;
        }

        public float RemainingSeconds
        {
            get => _ramainingSeconds;
            set
            {
                if (value <= 0f) throw new ArgumentException(nameof(value));
                _ramainingSeconds = value;
            }
        }

        public void Tick(float deltaTime)
        {
            if (RemainingSeconds == 0f) return;
            
            _ramainingSeconds -= deltaTime;
            CheckForTimerEnd();
        }

        private void CheckForTimerEnd()
        {
            if (RemainingSeconds > 0f) return;
            
            _ramainingSeconds = 0f;
            OnTimerEnd?.Invoke();
        }
    }   
}