using Unity.VisualScripting;
using UnityEngine;

namespace BS.Units.Weapons
{
    public class PoisonField : MonoBehaviour
    {
        private readonly float _lifeTime = 7f;

        private void Start()
        {
            Destroy(gameObject, _lifeTime);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out IDamageable unit) && !other.TryGetComponent(out PoisonEffect poisonEffect))
                other.AddComponent<PoisonEffect>();
        }
    }
}