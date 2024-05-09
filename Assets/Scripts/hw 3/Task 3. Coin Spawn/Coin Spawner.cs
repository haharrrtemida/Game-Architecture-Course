using UnityEngine;

namespace hw3.task3
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private SpawnPointController _pointController;
        [SerializeField] private CoinFactory _currentFactory;
        
        private Timer _timer;

        private void Awake()
        {
            _timer = new Timer(_spawnCooldown);
            _timer.OnTimerEnd += Spawn;
        }

        private void Update() => _timer.Tick(Time.deltaTime);

        private void OnDestroy() => _timer.OnTimerEnd -= Spawn;

        private void Spawn()
        {
            _timer.Reset();

            if (_pointController.HasEmptyPoint == false)
                return;

            Coin spawnedCoin = _currentFactory.Get();
            _pointController.TakePoint(spawnedCoin);

            Debug.Log($"Заспавнил {spawnedCoin}");
        }
    }
}