using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BS.Units.BehaviorControl.Conditionals
{
    public class DistanceChecker : Conditional
    {
        [SerializeField] private float _range;
        [SerializeField] private SharedTransform _target;

        public override TaskStatus OnUpdate()
        {
            if (_target.Value == null)
                return TaskStatus.Failure;

            float distance = Vector3.Distance(_target.Value.position, transform.position);

            return distance <= _range ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}