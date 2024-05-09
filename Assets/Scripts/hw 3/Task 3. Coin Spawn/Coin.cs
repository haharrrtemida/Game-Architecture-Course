using System;
using UnityEngine;

namespace hw3.task3
{
    public class Coin : MonoBehaviour, ISpawnableObject
    {
        public event Action<ISpawnableObject> OnLifetimeEnded;

        public void SetPosition(Vector3 position) => transform.position = position;

        private void OnDestroy() => OnLifetimeEnded?.Invoke(this);
    }
}