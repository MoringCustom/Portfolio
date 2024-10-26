using System;
using BehaviorDesigner.Runtime;

namespace BS.Units.BehaviorControl.Variables
{
    [Serializable]
    public class SharedRagdollHandler : SharedVariable<RagdollHandler>
    {
        public static implicit operator SharedRagdollHandler(RagdollHandler value)
        {
            return new SharedRagdollHandler { Value = value };
        }
    }
}