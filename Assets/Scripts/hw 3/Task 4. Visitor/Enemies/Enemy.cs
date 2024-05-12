using System;
using UnityEngine;

namespace hw3.task4
{
    public abstract class Enemy : MonoBehaviour, ISpawnableObject
    {
        public event Action<ISpawnableObject> OnLifetimeEnded;

        private void OnDestroy() => OnLifetimeEnded?.Invoke(this);

        public abstract void Accept(IEnemyVisitor visitor);
        public void SetPosition(Vector3 position) => transform.position = position;
    }
}