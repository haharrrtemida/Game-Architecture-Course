using UnityEngine;

namespace hw2
{
    [RequireComponent(typeof(Animator))]
    public class CharacterView : MonoBehaviour
    {
        private const string IS_MOVEMENT = "IsMovement";
        private const string IS_GROUNDED = "IsGrounded";
        private const string IS_IDLING = "IsIdling";
        private const string IS_WALKING = "IsWalking";
        private const string IS_RUNNIG = "IsRunning";
        private const string IS_SPRINTING = "IsSprinting";
        private const string IS_AIRBORNE = "IsAirborne";
        private const string IS_JUMPING = "IsJumping";
        private const string IS_FALLING = "IsFalling";

        private Animator _animator;

        public void Initialize() => _animator = GetComponent<Animator>();

        public void StartMovement() => _animator.SetBool(IS_MOVEMENT, true);
        public void StopMovement() => _animator.SetBool(IS_MOVEMENT, false);

        public void StartGrounded() => _animator.SetBool(IS_GROUNDED, true);
        public void StopGrounded() => _animator.SetBool(IS_GROUNDED, false);
        
        public void StartIdling() => _animator.SetBool(IS_IDLING, true);
        public void StopIdling() => _animator.SetBool(IS_IDLING, false);

        public void StartWalking() => _animator.SetBool(IS_WALKING, true);
        public void StopWalking() => _animator.SetBool(IS_WALKING, false);

        public void StartRunning() => _animator.SetBool(IS_RUNNIG, true);
        public void StopRunning() => _animator.SetBool(IS_RUNNIG, false);

        public void StartSprinting() => _animator.SetBool(IS_SPRINTING, true);
        public void StopSprinting() => _animator.SetBool(IS_SPRINTING, false);

        public void StartAirborne() => _animator.SetBool(IS_AIRBORNE, true);
        public void StopAirborne() => _animator.SetBool(IS_AIRBORNE, false);

        public void StartFalling() => _animator.SetBool(IS_FALLING, true);
        public void StopFalling() => _animator.SetBool(IS_FALLING, false);
        
        public void StartJumping() => _animator.SetBool(IS_JUMPING, true);
        public void StopJumping() => _animator.SetBool(IS_JUMPING, false);
    }
}