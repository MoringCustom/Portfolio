using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BS.Units
{
    [RequireComponent(typeof(AnimatorController))]
    [RequireComponent(typeof(UnitRemover))]
    public class RagdollHandler : MonoBehaviour
    {
        [SerializeField] private Rigidbody _mainBone;
        [SerializeField] private Rigidbody _mainRigidbody;
        [SerializeField] private Collider _hitBox;

        private AnimatorController _animatorController;
        private List<Rigidbody> _rigidbodies;
        private UnitRemover _unitDiver;
        private FixedJoint _joint;
        private bool _isEnable;

        public bool IsEnable => _isEnable;

        private void Awake()
        {
            _animatorController = GetComponent<AnimatorController>();
            _unitDiver = GetComponent<UnitRemover>();
            _rigidbodies = new List<Rigidbody>(_mainBone.GetComponentsInChildren<Rigidbody>());
        }

        private void Start()
        {
            TurnOn(false);
        }

        public void Hit(Vector3 force, Vector3 position)
        {
            if (!_hitBox.enabled)
                return;

            TurnOn(true);
            _joint = _mainBone.AddComponent<FixedJoint>();
            _joint.connectedBody = _mainRigidbody;
            _mainBone.AddForceAtPosition(force, _mainBone.ClosestPointOnBounds(position), ForceMode.Impulse);
        }

        public void TurnOn(bool value)
        {
            _isEnable = value;
            SetDollKinematic(!value);
            _animatorController.TurnOnAnimator(!value);

            if (value)
                _hitBox.enabled = !value;
            else
                Destroy(_joint);
        }

        public void RemoveBody()
        {
            _mainRigidbody.isKinematic = true;
            SetDollKinematic(true);
            _unitDiver.StartRemove();
        }

        private void SetDollKinematic(bool value)
        {
            foreach (Rigidbody rigidbody in _rigidbodies)
                rigidbody.isKinematic = value;
        }
    }
}