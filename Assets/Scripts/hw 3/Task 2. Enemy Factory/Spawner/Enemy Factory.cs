using UnityEngine;

namespace hw3.task2
{
    public abstract class EnemyFactory : ScriptableObject
    {
        public abstract Enemy Get(EnemyType type);
    }
}