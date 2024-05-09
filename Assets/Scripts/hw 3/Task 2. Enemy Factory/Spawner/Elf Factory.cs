using System;
using UnityEngine;

namespace hw3.task2
{
    [CreateAssetMenu(fileName = "Elf Factory", menuName = "hw3/Elf Factory", order = 0)]
    public class ElfFactory : EnemyFactory
    {
        [field: SerializeField] public ElfWizardConfig ElfWizardConfig { get; private set; }
        [field: SerializeField] public ElfPaladinConfig ElfPaladinConfig { get; private set; }
        public override Enemy Get(EnemyType type)
        {
            Enemy orc;
            float destroyTime = 0f;
            switch (type)
            {
                case EnemyType.Paladin:
                    orc = Instantiate(ElfPaladinConfig.Prefab);
                    destroyTime = ElfPaladinConfig.Lifetime;
                    break;
                case EnemyType.Wizard:
                    orc = Instantiate(ElfWizardConfig.Prefab);
                    destroyTime = ElfWizardConfig.Lifetime;
                    break;
                default:
                    throw new ArgumentException(nameof(type));
            }
            Destroy(orc.gameObject, destroyTime);
            return orc;
        }
    }
}