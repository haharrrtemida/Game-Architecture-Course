using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace hw1.task4
{
    [RequireComponent(typeof(BoxCollider))]
    public class BallsSpawner : MonoBehaviour
    {
        [SerializeField] private int _ballsCount;
        [SerializeField] private Ball _ballTemplate;
        private Dictionary<BallColor, Material> _ballsColorMaterialsBase;
        private BoxCollider _spawnZone;
        
        public List<Ball> BallsCollection { get; private set; }
        
        public void Initialize()
        {
            BallsCollection = new List<Ball>();
            _spawnZone = GetComponent<BoxCollider>();
            _ballsColorMaterialsBase = new Dictionary<BallColor, Material>()
            {
                { BallColor.Red, Resources.Load<Material>("red")},
                { BallColor.White, Resources.Load<Material>("white") },
                { BallColor.Green, Resources.Load<Material>("green") }
            };
            SpawnBalls();
        }

        public int GetBallsCount(BallColor color)
        {
            var a = BallsCollection.Where(x => x.BallColor == color);
            return a.Count();
        }

        public void RemoveBallFromCollection(Ball ball)
        {
            BallsCollection.Remove(ball);
        }
        
        private void SpawnBalls()
        {
            for (int i = 0; i < _ballsCount; i++)
            {
                SpawnBall();
            }
        }

        private void SpawnBall()
        {
            Vector3 position = GetRandomSpawnPosition();
            BallColor ballColor = GetRandomBallColor();
            Ball ball = Instantiate(_ballTemplate, position, Quaternion.identity);
            ball.Initialize(ballColor, _ballsColorMaterialsBase[ballColor]);
            BallsCollection.Add(ball);
        }

        private Vector3 GetRandomSpawnPosition()
        {
            Vector3 pos;
            pos.x = Random.Range(_spawnZone.bounds.min.x, _spawnZone.bounds.max.x);
            pos.y = Random.Range(_spawnZone.bounds.min.y, _spawnZone.bounds.max.y);
            pos.z = Random.Range(_spawnZone.bounds.min.z, _spawnZone.bounds.max.z);
            return pos;
        }

        private BallColor GetRandomBallColor()
        {
            int index = Random.Range(0, _ballsColorMaterialsBase.Count);
            return _ballsColorMaterialsBase.ElementAt(index).Key;
        }
    }
}