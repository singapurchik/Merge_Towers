using UnityEngine;

namespace MT.Core
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(CharacterMover))]
    [RequireComponent(typeof(CharacterEffects))]
    [RequireComponent(typeof(CharacterAnimator))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        
        private Health _health;
        private CharacterMover _mover;
        private BoxCollider _boxCollider;
        private Fighter _fighter;
        private CharacterAnimator _animator;
        private CharacterEffects _effects;
        private Health _currentTarget;

        public Health Health => _health;

        private bool _isFight;
        private bool _isLastHit;
        private bool _isGameOver;
        private bool _isDead;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _fighter = GetComponent<Fighter>();
            _animator = GetComponent<CharacterAnimator>();
            _boxCollider = GetComponent<BoxCollider>();
            _mover = GetComponent<CharacterMover>();
            _effects = GetComponent<CharacterEffects>();
            _health.Initialize(1);
            _mover.Initialize();
        }

        private void OnEnable()
        {
            _health.Died += Die;
        }

        private void OnDisable()
        {
            _health.Died -= Die;
        }

        private void Update()
        {
            if(_isGameOver || _isFight) return;
            _mover.MoveForward();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Health health) && health.Type != _health.Type)
            {
                _currentTarget = health;
                _fighter.SetTarget(_currentTarget);
                Fight();
            }

            if (other.TryGetComponent(out CastlePart castle))
                _isLastHit = true;
        }

        private void OnTriggerStay(Collider other)
        {
            if(_currentTarget != null) return;
            if (other.TryGetComponent(out Health health) && health.Type != _health.Type)
            {
                _currentTarget = health;
                _fighter.SetTarget(_currentTarget);
                Fight();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(_currentTarget != null)
                Move();
        }

        private void Fight()
        {
            _isFight = true;
            _animator.FightAnim();
        }

        private void Move()
        {
            _currentTarget = null;
            _fighter.RemoveTarget();
            _isFight = false;
            _animator.MoveAnim();
        }

        public void Die()
        {
            if(_isDead) return;
            _isDead = true;
            _animator.DisableAnimator();
            _body.SetActive(false);
            _effects.BloodVFX();
            CoinForEnemy();
            _fighter.DestroyProjectiles();
            _boxCollider.enabled = false;
            //Destroy(gameObject);
            enabled = false;
        }

        private void CoinForEnemy()
        {
            if (_health.Type != HealthType.Enemy) return;
            _effects.CoinVFX();
            EventManager.TriggerEvent(CustomEventType.AddScore, null);
        }

        public void Win()
        {
            _isGameOver = true;
            _animator.WinAnim();
        }

        //animation events
        public void DealDamage()
        {
            if(_currentTarget == null) return;
            
            _fighter.Damage(_currentTarget);

            if (_isLastHit)
            {
                Die();
            }
            else
            {
                if (_currentTarget.CurrentHealth <= 0)
                    Move();   
            }
        }

        public void LastHit()
        {
            if(_isLastHit)
                Die();
        }
    }
}
