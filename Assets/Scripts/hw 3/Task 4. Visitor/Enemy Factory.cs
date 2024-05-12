using System;
using UnityEngine;

namespace hw3.task4
{
    [CreateAssetMenu(fileName = "Enemy Factory", menuName = "hw3/Enemy Factory")]
    public class EnemyFactory : ScriptableObject
    {
        [SerializeField] private Human _humanPrefab;
        [SerializeField] private Elf _elfPrefab;
        [SerializeField] private Orc _orcPrefab;
        
        public Enemy Get(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Elf:
                    return Instantiate(_elfPrefab);
                case EnemyType.Human:
                    return Instantiate(_humanPrefab);
                case EnemyType.Orc:
                    return Instantiate(_orcPrefab);
                default:
                    throw new ArgumentException(nameof(type));
            }
        }
    }
}