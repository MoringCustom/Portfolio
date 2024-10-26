using System;
using BehaviorDesigner.Runtime;

namespace BS.Units.BehaviorControl.Variables
{
    [Serializable]
    public class SharedUnit : SharedVariable<Unit>
    {
        public static implicit operator SharedUnit(Unit value)
        {
            return new SharedUnit { Value = value };
        }
    }
}