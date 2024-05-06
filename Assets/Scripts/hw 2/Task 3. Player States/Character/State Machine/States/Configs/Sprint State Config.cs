using System;
using UnityEngine;

namespace hw2.task3.PlayerState
{
    [Serializable]

    public class SprintStateConfig
    {
        [field: SerializeField, Range(0, 10)] public float Speed { get; private set; }
    }
}