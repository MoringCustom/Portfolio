using BS.Units.Movement;
using UnityEngine;

namespace BS.Environment
{
    public class StonesMound : Trap
    {
        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out MoundHandler unit))
                unit.Fell();
        }
    }
}