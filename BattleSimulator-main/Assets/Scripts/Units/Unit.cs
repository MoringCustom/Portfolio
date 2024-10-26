using BehaviorDesigner.Runtime;
using BS.Units.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace BS.Units
{
    [RequireComponent(typeof(BehaviorTree))]
    [RequireComponent(typeof(RagdollHandler))]
    public class Unit : MonoBehaviour, IDamageable
    {
        private readonly float _deathDelay = 2.5f;

        [SerializeField] private int _price;
        [SerializeField] private int _health;
        [SerializeField] private Weapon _weapon;

        private RagdollHandler _ragdollHandler;
        private BehaviorTree _behaviorTree;
        private Transform _targetParent;
        private Transform _transform;
        private Button _startButton;
        private float _startYPosition;
        private bool _isEnemy;

        public int Health => _health;
        public int Price => _price;
        public bool IsEnemy => _isEnemy;
        public Transform TargetParent => _targetParent;
        protected Weapon UnitWeapon => _weapon;

        private void Awake()
        {
            _transform = transform;
            _startYPosition = _transform.position.y;
            _behaviorTree = GetComponent<BehaviorTree>();
            _ragdollHandler = GetComponent<RagdollHandler>();
        }

        public void Init(bool isEnemy, Transform targetParent, Button startButton)
        {
            _isEnemy = isEnemy;
            _startButton = startButton;
            _targetParent = targetParent;
            _weapon.SetBattleSide(isEnemy);
            _startButton.onClick.AddListener(StartBattle);
        }

        public void ResetCurrentPosition()
        {
            var direction = Vector3.ProjectOnPlane(_transform.forward, Vector3.up);

            _transform.position = new Vector3(_transform.position.x, _startYPosition, _transform.position.z);
            _transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }

        public void TakeDamage(int damage)
        {
            if (_health <= 0)
                return;

            _health -= damage;

            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
        }

        public void Hit(Vector3 force, Vector3 position)
        {
            _ragdollHandler.Hit(force, position);
        }

        protected void ResetWeapon()
        {
            _weapon = null;
        }

        private void Die()
        {
            _weapon.enabled = false;
            _transform.parent = null;
            _ragdollHandler.TurnOn(true);
            _startButton.onClick.RemoveListener(StartBattle);
            Invoke(nameof(RemoveBody), _deathDelay);
        }

        private void RemoveBody()
        {
            _behaviorTree.enabled = false;
            _ragdollHandler.RemoveBody();
        }

        private void StartBattle()
        {
            _behaviorTree.enabled = true;
        }
    }
}