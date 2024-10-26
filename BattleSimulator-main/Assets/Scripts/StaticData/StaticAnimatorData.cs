using UnityEngine;

namespace BS.StaticData
{
    public static class StaticAnimatorData
    {
        public static readonly int State = Animator.StringToHash("State");
        public static readonly int Attack = Animator.StringToHash("Attack");
        public static readonly int GettingUp = Animator.StringToHash("GettingUp");
    }
}