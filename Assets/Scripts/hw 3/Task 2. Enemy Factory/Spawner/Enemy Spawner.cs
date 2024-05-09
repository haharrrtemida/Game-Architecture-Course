using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace hw3.task2
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyRace _race;
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private SpawnPointController _pointController;

        private EnemyFactory _currentFactory;
        private Timer _timer;

        private void Awake()
        {
            InitFabric(_race);

            _timer = new Timer(_spawnCooldown);
            _timer.OnTimerEnd += Spawn;
        }

        private void Update() => _timer.Tick(Time.deltaTime);

        private void OnDestroy() => _timer.OnTimerEnd -= Spawn;

        public void ChangeFabric()
        {
            switch (_race)
            {
                case EnemyRace.Orc:
                    _race = EnemyRace.Elf;
                    break;
                case EnemyRace.Elf:
                    _race = EnemyRace.Orc;
                    break;
            }
            InitFabric(_race);
        }
        
        private void Spawn()
        {
            _timer.Reset();

            int type = GetRandomEnemyType();
            var spawnedEnemy = _currentFactory.Get((EnemyType)type);
            
            _pointController.TakePoint(spawnedEnemy);
            

            Debug.Log($"Заспавнил {spawnedEnemy}");
        }

        private int GetRandomEnemyType()
        {
            int enemyTypesCount = Enum.GetNames(typeof(EnemyType)).Length;
            int randomType = Random.Range(0, enemyTypesCount);
            return randomType;
        }

        private void InitFabric(EnemyRace race)
        {
            UnityEngine.Object factory;
            switch (race)
            {
                case EnemyRace.Orc:
                    factory = Resources.Load("Ork Factory") as OrcFactory;
                    break;
                case EnemyRace.Elf:
                    factory = Resources.Load("Elf Factory") as ElfFactory;
                    break;
                default:
                    throw new InvalidOperationException($"{race} race isn't supported");
            }
            _currentFactory = factory as EnemyFactory;
        }

    }
}