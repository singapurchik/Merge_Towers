using UnityEngine;

namespace MT.Core
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(MeshRenderer))]
    public class Projectile : MonoBehaviour, IDamageDealer
    {
        [Range(1, 20)] [SerializeField] private int _damage = 1;
        [SerializeField] private HealthType _healthType;

        private BoxCollider _boxCollider;
        private MeshRenderer _meshRenderer;
        private Transform _target;

        private bool _shoot;
        private float _yStep = 0.75f;
        private float _moveSpeed = 10f;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Health health) || health.Type == _healthType) return;
            _shoot = false;
            Damage(health);
        }

        private void Update()
        {
            if(!_shoot) return;
            Move();
        }

        public void Damage(Health target)
        {
            target.TakeDamage(_damage);
            DestroyProjectile();
        }

        public void Shoot(Transform target)
        {
            if (_boxCollider == null)
                _boxCollider = GetComponent<BoxCollider>();

            _target = target;
            _boxCollider.enabled = true;
            transform.SetParent(transform.root);
            LookOnTarget();
            _shoot = true;
        }
        
        private void Move()
        {
            if (InMove())
                ProcessMove();
            else
                Destroy(gameObject); 
        }
        
        private void LookOnTarget()
        {
            var target = _target.position;
            target.y += _yStep;
            transform.LookAt(target);
            transform.eulerAngles = new Vector3(90f, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        private void ProcessMove()
        {
            var speed = _moveSpeed * Time.deltaTime;
            var target = _target.position;
            target.y += _yStep;
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
        }

        private bool InMove()
        {

            return Vector3.Distance(transform.position, _target.position) > _yStep;
        }

        public void DestroyProjectile()
        {
            _boxCollider.enabled = false;
            _meshRenderer.enabled = false;
        }
    }
}