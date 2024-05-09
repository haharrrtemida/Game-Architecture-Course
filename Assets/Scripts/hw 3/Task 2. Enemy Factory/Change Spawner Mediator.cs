using UnityEngine;
using UnityEngine.UI;

namespace hw3.task2
{
    public class ChangeSpawnerMediator : MonoBehaviour
    {
        [SerializeField] private Button _swapButton;
        [SerializeField] private EnemySpawner _firstSpawner;
        [SerializeField] private EnemySpawner _secondSpawner;
        
        private void Awake() => _swapButton.onClick.AddListener(OnButtonClick);

        private void OnDestroy() => _swapButton.onClick.RemoveAllListeners();

        private void OnButtonClick()
        {
            _firstSpawner.ChangeFabric();
            _secondSpawner.ChangeFabric();
        }
    }
}