using UnityEngine;

namespace hw3.task4
{
    [CreateAssetMenu(fileName = "Enemy Weight Config", menuName = "hw3/Enemy Weight Config", order = 0)]
    public class EnemyWeightConfig : ScriptableObject
    {
        [field: SerializeField] public float ElfWeight;
        [field: SerializeField] public float HumanWeight;
        [field: SerializeField] public float OrcWeight;
    }
}