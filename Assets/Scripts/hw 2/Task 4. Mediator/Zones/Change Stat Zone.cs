using UnityEngine;

namespace hw2.task4.Mediator
{
    public abstract class ChangeStatZone : MonoBehaviour
    {
        [SerializeField] private float _changeValue;
        [SerializeField] private StatType _whichStatShouldChange;

        protected float ChangeValue => _changeValue;

        protected abstract void MakeChanges(Stat stats);

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out StatsManager stats))
            {
                MakeChanges(stats.Stats[_whichStatShouldChange]);
            }
        }
    }
}