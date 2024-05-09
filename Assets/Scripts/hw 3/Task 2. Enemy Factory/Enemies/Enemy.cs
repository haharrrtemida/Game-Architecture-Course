using System;
using UnityEngine;

namespace hw3.task2
{
    public abstract class Enemy : MonoBehaviour
    {
        public event Action<Enemy> OnLifetimeEnded;

        private void OnDestroy() => OnLifetimeEnded?.Invoke(this);
    }
}