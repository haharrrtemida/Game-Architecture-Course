using System;
using UnityEngine;

namespace hw3.task4
{
    public class WeightSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private SpawnPointController _pointController;
        [SerializeField] private EnemyFactory _currentFactory;
        [SerializeField] private EnemyWeightConfig _enemyConfig;
        [SerializeField] private float _maxWeight = 25;
        
        private Timer _timer;
        private SpawnerWeightVisitor _spawnerWeightVisitor;

        private void Awake()
        {
            _timer = new Timer(_spawnCooldown);
            _timer.OnTimerEnd += Spawn;
            _spawnerWeightVisitor = new SpawnerWeightVisitor(_enemyConfig);
        }

        private void Update() => _timer.Tick(Time.deltaTime);
        private void OnDestroy() => _timer.OnTimerEnd -= Spawn;
        
        private void Spawn()
        {
            _timer.Reset();
            
            if (_pointController.HasEmptyPoint == false)
                return;

            if (_spawnerWeightVisitor.Weight >= _maxWeight)
                return;
            
            int type = GetRandomEnemyType();
            var spawnedEnemy = _currentFactory.Get((EnemyType)type);
            
            _pointController.TakePoint(spawnedEnemy);
            spawnedEnemy.Accept(_spawnerWeightVisitor);
            
            Debug.Log($"Заспавнил {spawnedEnemy}");
            Debug.Log($"Общий вес врагов: {_spawnerWeightVisitor.Weight}");
        }

        private int GetRandomEnemyType()
        {
            int enemyTypesCount = Enum.GetNames(typeof(EnemyType)).Length;
            int randomType = UnityEngine.Random.Range(0, enemyTypesCount);
            return randomType;
        }

        private class SpawnerWeightVisitor : IEnemyVisitor
        {
            private EnemyWeightConfig _config;
            
            public SpawnerWeightVisitor(EnemyWeightConfig config) => _config = config;

            public float Weight { get; private set; }

            public void Visit(Elf elf) => Weight += _config.ElfWeight;
            public void Visit(Human human) => Weight += _config.HumanWeight;
            public void Visit(Orc orc) => Weight += _config.OrcWeight;
        }
    }
}