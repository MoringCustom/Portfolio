using BS.StaticData;
using UnityEngine;

namespace BS.Units
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorController : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public bool CanMove()
        {
            var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

            return stateInfo.IsName(AnimatorStates.Attack.ToString());
        }

        public void SetState(AnimatorStates state)
        {
            if (_animator.GetInteger(StaticAnimatorData.State) != (int)state)
                _animator.SetInteger(StaticAnimatorData.State, (int)state);
        }

        public void SetTrigger(int name)
        {
            _animator.SetTrigger(name);
        }

        public void TurnOnAnimator(bool value)
        {
            _animator.enabled = value;
        }
    }
}