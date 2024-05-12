using System;
using UnityEngine;

namespace hw3.task2
{
    public abstract class Enemy : MonoBehaviour, ISpawnableObject
    {
        public event Action<ISpawnableObject> OnLifetimeEnded;

        public void SetPosition(Vector3 position) => transform.position = position;

        private void OnDestroy() => OnLifetimeEnded?.Invoke(this);
    }
}