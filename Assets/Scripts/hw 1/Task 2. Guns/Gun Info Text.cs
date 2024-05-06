using TMPro;
using UnityEngine;

namespace hw1.task2
{
    public class GunInfoText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _gunNameText;
        [SerializeField] private TextMeshProUGUI _currentBulletsText;
        [SerializeField] private TextMeshProUGUI _allBulletsText;
        [SerializeField] private GunInputHandler _gunInputHandler;

        private void Awake()
        {
            _gunInputHandler.OnGunChanged += UpdateInfo;
            _gunInputHandler.OnGunInfoChanged += UpdateInfo;
        }

        private void UpdateInfo(Gun gun)
        {
            string currentBulletsText = gun.Data.IsInfinite? "∞" : gun.BulletsinClipCount.ToString();
            string allBulletsText = gun.Data.IsInfinite? "∞" : gun.BulletsCount.ToString();

            _gunNameText.text = gun.Data.Name;
            _currentBulletsText.text = currentBulletsText;
            _allBulletsText.text = allBulletsText;
        }

        private void OnDestroy()
        {
            _gunInputHandler.OnGunChanged -= UpdateInfo;
            _gunInputHandler.OnGunInfoChanged -= UpdateInfo;
        }
    }
}