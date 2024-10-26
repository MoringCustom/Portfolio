using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BS.StaticData;
using BS.Units.BehaviorControl.Variables;
using UnityEngine;

namespace BS.Units.BehaviorControl.Actions
{
    public class AttackAction : Action
    {
        [SerializeField] private SharedAnimatorController _animatorController;
        [SerializeField] private SharedTransform _target;

        public override TaskStatus OnUpdate()
        {
            if (_target.Value == null)
                return TaskStatus.Failure;

            if (_target.Value.TryGetComponent(out IDamageable unit))
            {
                transform.LookAt(_target.Value);
                _animatorController.Value.SetTrigger(StaticAnimatorData.Attack);
                return TaskStatus.Success;
            }

            return TaskStatus.Failure;
        }
    }
}