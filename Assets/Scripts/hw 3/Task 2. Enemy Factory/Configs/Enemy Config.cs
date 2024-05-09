using System;
using UnityEngine;

namespace hw3.task2
{
    [Serializable]
    public class EnemyConfig
    {
        [field: SerializeField] public Enemy Prefab;
        [field: SerializeField] public float Lifetime;
    }
}