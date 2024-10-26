using System;
using UnityEngine;

namespace BS.City.PlayerControl
{
    internal class Player : MonoBehaviour
    {
        public event Action Gone;
        public event Action<BuildingInteraction> Entered;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BuildingInteraction buildingInteraction))
                Entered?.Invoke(buildingInteraction);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out BuildingInteraction buildingInteraction))
                Gone?.Invoke();
        }
    }
}