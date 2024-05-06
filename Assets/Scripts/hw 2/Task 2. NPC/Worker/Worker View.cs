using UnityEngine;

namespace hw2.task2.NPC
{
    [RequireComponent(typeof(Animator))]
    public class WorkerView : MonoBehaviour
    {
        private const string IS_WALKING = "IsWalking";
        private const string IS_BUSY = "IsBusy";
        private const string IS_MINING = "IsMining";
        private const string IS_RESTING = "IsResting";

        private Animator _animator;

        public void Initialize() => _animator = GetComponent<Animator>();

        public void StartWalking() => _animator.SetBool(IS_WALKING, true);
        public void StopWalking() => _animator.SetBool(IS_WALKING, false);

        public void StartBusy() => _animator.SetBool(IS_BUSY, true);
        public void StopBusy() => _animator.SetBool(IS_BUSY, false);

        public void StartMining() => _animator.SetBool(IS_MINING, true);
        public void StopMining() => _animator.SetBool(IS_MINING, false);

        public void StartResting() => _animator.SetBool(IS_RESTING, true);
        public void StopResting() => _animator.SetBool(IS_RESTING, false);
    }
}