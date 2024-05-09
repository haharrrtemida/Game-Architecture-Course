using UnityEngine;

namespace hw3.task3
{
    [CreateAssetMenu(fileName = "Coin Factory", menuName = "hw3/Coin Factory", order = 0)]
    public class CoinFactory : ScriptableObject
    {
        [SerializeField] private Coin _coin;

        public Coin Get() => Instantiate(_coin);
    }
}