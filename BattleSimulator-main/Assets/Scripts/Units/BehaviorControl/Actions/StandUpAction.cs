using BehaviorDesigner.Runtime.Tasks;
using BS.StaticData;
using BS.Units.BehaviorControl.Variables;
using UnityEngine;

namespace BS.Units.BehaviorControl.Actions
{
    public class StandUpAction : Action
    {
        [SerializeField] private SharedUnit _unit;
        [SerializeField] private SharedRagdollHandler _ragdollHandler;
        [SerializeField] private SharedAnimatorController _animatorController;
        [SerializeField] private Rigidbody _rigidbody;

        public override TaskStatus OnUpdate()
        {
            _unit.Value.ResetCurrentPosition();
            _ragdollHandler.Value.TurnOn(false);
            _animatorController.Value.SetTrigger(StaticAnimatorData.GettingUp);
            _rigidbody.isKinematic = true;

            return TaskStatus.Success;
        }
    }
}