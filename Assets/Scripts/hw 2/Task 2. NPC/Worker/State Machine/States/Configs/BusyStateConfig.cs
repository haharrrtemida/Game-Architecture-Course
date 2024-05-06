using System;
using UnityEngine;

namespace hw2.task2.NPC
{
    [Serializable]
    public class BusyStateConfig
    {
        [field: SerializeField, Range(0, 10)] public float Time { get; private set; }
    }
}