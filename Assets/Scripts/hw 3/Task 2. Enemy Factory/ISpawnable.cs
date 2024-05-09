using System;
using UnityEngine;

namespace hw3
{
    public interface ISpawnableObject
    {
        event Action<ISpawnableObject> OnLifetimeEnded;
        void SetPosition(Vector3 position);
    }
}