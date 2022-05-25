using UnityEngine;

namespace MT.Core
{
    public class Fighter : MonoBehaviour, IDamageDealer
    {
        [Range(1, 20)] [SerializeField] private int _damage = 1;
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _projectilePos;

        private Projectile _currentProjectile;
        private Health _currentTarget;

        public void Damage(Health target)
        {
            target.TakeDamage(_damage);
        }
        
        public void SetTarget(Health target)
        {
            _currentTarget = target;
        }

        public void RemoveTarget()
        {
            _currentTarget = null;
        }

        //animation events
        public void SpawnProjectile()
        {
            if(_currentProjectile != null) return;
            
            var newProjectile = Instantiate(_projectilePrefab, _projectilePos.position, 
                _projectilePos.rotation, _projectilePos);
            _currentProjectile = newProjectile;
        }

        public void Shoot()
        {
            if(_currentProjectile == null || _currentTarget == null) return;
            _currentProjectile.Shoot(_currentTarget.transform);
            _currentProjectile = null;
        }

        public void DestroyProjectiles()
        {
            if(_currentProjectile == null) return;
            _currentProjectile.DestroyProjectile();
            _currentProjectile = null;
        }
    }
}
