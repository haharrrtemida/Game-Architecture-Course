using System;
using UnityEngine;

namespace hw2.task3.PlayerState
{  
    public class StateMachineData
    {
        public Vector2 XZVelocity;
        public float YVelocity;

        private float _speed;
        private Vector2 _xzInput;

        public Vector2 XZInput
        {
            get => _xzInput;
            set
            {
                if (value.x < -1 || value.x > 1 || value.y < -1 || value.y > 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                
                _xzInput = value;
            }
        }

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
    }
}