using BehaviorDesigner.Runtime.Tasks;
using BS.Units.BehaviorControl.Variables;
using UnityEngine;

namespace BS.Units.BehaviorControl.Conditionals
{
    public class RagdollChecker : Conditional
    {
        [SerializeField] private SharedRagdollHandler _ragdoll;

        public override TaskStatus OnUpdate()
        {
            return _ragdoll.Value.IsEnable ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}