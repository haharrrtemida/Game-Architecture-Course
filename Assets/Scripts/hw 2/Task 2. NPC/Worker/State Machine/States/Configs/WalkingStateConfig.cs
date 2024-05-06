using System;
using UnityEngine;

namespace hw2.task2.NPC
{
    [Serializable]
    public class WalkingStateConfig
    {
        [field: SerializeField, Range(0, 10)] public float Speed { get; private set; }
        [field: SerializeField, Range(0, 10)] public float StopingDistance { get; private set; }
    }
}