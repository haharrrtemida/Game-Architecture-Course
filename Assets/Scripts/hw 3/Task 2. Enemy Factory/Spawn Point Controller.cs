using System.Collections.Generic;
using UnityEngine;

namespace hw3
{   
    public class SpawnPointController : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints;
        
        private Dictionary<ISpawnableObject, Transform> _busySpawnPoints;

        public List<Transform> SpawnPoints => _spawnPoints;

        public bool HasEmptyPoint => _spawnPoints.Count > 0;

        private void Awake()
        {
            _busySpawnPoints = new Dictionary<ISpawnableObject, Transform>();
        }

        public void TakePoint(ISpawnableObject enemy)
        {
            Transform point = GetFreePoint();
            _busySpawnPoints.Add(enemy, point);
            enemy.OnLifetimeEnded += ReleasePoint;
            enemy.SetPosition(point.position);
        }

        private Transform GetFreePoint()
        {
            int index = Random.Range(0, _spawnPoints.Count);
            Transform point = _spawnPoints[index];
            _spawnPoints.RemoveAt(index);
            return point;
        }

        private void ReleasePoint(ISpawnableObject enemy)
        {
            enemy.OnLifetimeEnded -= ReleasePoint;

            Transform point = _busySpawnPoints[enemy];
            _busySpawnPoints.Remove(enemy);
            _spawnPoints.Add(point);
        }

        [ContextMenu("Despawn Item")]
        private void DespawnItem()
        {
            if (_busySpawnPoints.Count < 0)
                return;

            ISpawnableObject item = GetRandomSpawnedObject();
            Destroy((item as MonoBehaviour).gameObject);
        }

        private ISpawnableObject GetRandomSpawnedObject()
        {
            List<ISpawnableObject> keys = new List<ISpawnableObject>(_busySpawnPoints.Keys);
            int index = Random.Range(0, keys.Count);
            return keys[index];
        }
    }
}