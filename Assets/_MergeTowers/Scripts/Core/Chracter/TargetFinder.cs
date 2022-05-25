using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MT.Core
{
    [RequireComponent(typeof(Health))]
    public class TargetFinder : MonoBehaviour
    {
        private List<Health> _targets = new List<Health>();
        private Health _health;
        private Health _currentTarget;

        public List<Health> Targets => _targets;

        public void Initialize()
        {
            _health = GetComponent<Health>();
            FindAllTargets();
        }

        public void FindAllTargets()
        {
            RemoveTargets();
            foreach (var health in FindObjectsOfType<Health>().Where(health => health.Type != _health.Type && health.CurrentHealth > 0))
                _targets.Add(health);
        }

        public Health FindClosestTarget()
        {
            var closestDistanceSqr = Mathf.Infinity;

            foreach (var target in _targets)
            {
                var directionToTarget = target.transform.position - transform.position;
                var dSqrToTarget = directionToTarget.sqrMagnitude;

                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    _currentTarget = target;
                }
            }

            return _currentTarget;
        }

        public void RemoveTargets()
        {
            _currentTarget = null;
            _targets.Clear();
        }
    }
}