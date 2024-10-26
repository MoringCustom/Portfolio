using System;
using BehaviorDesigner.Runtime;
using BS.Units.Movement;

namespace BS.Units.BehaviorControl.Variables
{
    [Serializable]
    public class SharedMovementSource : SharedVariable<BotMovementSource>
    {
        public static implicit operator SharedMovementSource(BotMovementSource value)
        {
            return new SharedMovementSource { Value = value };
        }
    }
}