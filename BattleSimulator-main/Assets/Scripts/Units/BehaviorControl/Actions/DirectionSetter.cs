using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BS.Units.BehaviorControl.Actions
{
    public class DirectionSetter : Action
    {
        [SerializeField] private SharedTransform _target;
        [SerializeField] private SharedVector3 _direction;

        public override TaskStatus OnUpdate()
        {
            if (_target.Value == null)
                return TaskStatus.Failure;

            Vector3 direction = Vector3.ProjectOnPlane(_target.Value.position - transform.position, Vector3.up);
            _direction.Value = direction.normalized;

            return TaskStatus.Success;
        }
    }
}