using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BS.Units.BehaviorControl.Variables;
using UnityEngine;

namespace BS.Units.BehaviorControl.Actions
{
    public class MovementSourceSetter : Action
    {
        [SerializeField] private SharedMovementSource _movementSource;
        [SerializeField] private SharedVector3 _direction;

        public override TaskStatus OnUpdate()
        {
            _movementSource.Value.SetDirection(_direction.Value);

            return TaskStatus.Success;
        }
    }
}