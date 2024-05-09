using System.Collections.Generic;
using UnityEngine;

namespace hw3.task2
{   
    public class SpawnPointController : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints;
        
        private Dictionary<Enemy, Transform> _busySpawnPoints;

        public List<Transform> SpawnPoints => _spawnPoints;

        private void Awake()
        {
            _busySpawnPoints = new Dictionary<Enemy, Transform>();
        }

        public void TakePoint(Enemy enemy)
        {
            Transform point = GetFreePoint();
            _busySpawnPoints.Add(enemy, point);
            enemy.OnLifetimeEnded += ReleasePoint;
            enemy.transform.position = point.position;
        }

        private Transform GetFreePoint()
        {
            int index = Random.Range(0, _spawnPoints.Count);
            Transform point = _spawnPoints[index];
            _spawnPoints.RemoveAt(index);
            return point;
        }

        private void ReleasePoint(Enemy enemy)
        {
            Transform point = _busySpawnPoints[enemy];
            _busySpawnPoints.Remove(enemy);
            _spawnPoints.Add(point);
        }

    }
}