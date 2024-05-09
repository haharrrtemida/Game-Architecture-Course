using System;
using UnityEngine;

namespace hw3.task2
{
    [CreateAssetMenu(fileName = "Ork Factory", menuName = "hw3/Ork Factory", order = 0)]
    public class OrcFactory : EnemyFactory
    {
        [field: SerializeField] public OrcWizardConfig OrcWizardConfig { get; private set; }
        [field: SerializeField] public OrcPaladinConfig OrcPaladinConfig { get; private set; }
        public override Enemy Get(EnemyType type)
        {
            Enemy orc;
            float destroyTime = 0f;
            switch (type)
            {
                case EnemyType.Paladin:
                    orc = Instantiate(OrcPaladinConfig.Prefab);
                    destroyTime = OrcPaladinConfig.Lifetime;
                    break;
                case EnemyType.Wizard:
                    orc = Instantiate(OrcWizardConfig.Prefab);
                    destroyTime = OrcWizardConfig.Lifetime;
                    break;
                default:
                    throw new ArgumentException(nameof(type));
            }
            Destroy(orc.gameObject, destroyTime);
            return orc;
        }
    }
}