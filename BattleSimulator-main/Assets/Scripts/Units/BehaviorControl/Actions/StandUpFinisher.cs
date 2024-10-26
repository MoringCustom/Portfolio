using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BS.Units.BehaviorControl.Actions
{
    public class StandUpFinisher : Action
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _hitBox;

        public override TaskStatus OnUpdate()
        {
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _hitBox.enabled = true;

            return TaskStatus.Success;
        }
    }
}