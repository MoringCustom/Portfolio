using UnityEngine;

namespace Assets.Scripts.Wallet
{
    public class Money : MonoBehaviour
    {
        private uint _value;

        public uint Value => _value;

        public void SetValue(uint value)
        {
            _value = value;
        }
    }
}