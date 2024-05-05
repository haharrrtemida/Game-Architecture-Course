using UnityEngine;

namespace hw2.task4.Mediator
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private StatsManager _playerStatManager;
        [SerializeField] private StatsMediator _statsMediator;
        
        private void Awake()
        {
            _playerStatManager.Initialize();
            _statsMediator.Initialize(_playerStatManager);

        }
    }
}