using System;
using UnityEngine;

namespace MT.Core
{
    public class Health : MonoBehaviour, IKillable
    {
        [SerializeField] private HealthType _type;
        [SerializeField] private int[] _healths;
        
        private int _currentHealth;
        private int _healthIndex;

        public HealthType Type => _type;
        public int CurrentHealth => _currentHealth;
        public event Action GetDamage;
        public event Action Died;

        public void Initialize(int level)
        {
            _healthIndex = level - 1;
            UpdateHealth();
        }

        public void TakeDamage(int damage)
        {
            if(_currentHealth <= 0) return;
            
            if(damage < 0)
                throw new AggregateException(nameof(damage));

            _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _currentHealth);

            if (_currentHealth <= 0)
                Kill();
            else
                GetDamage?.Invoke();
        }

        public void Kill()
        {
            Died?.Invoke();
        }

        public void LevelUp()
        {
            _healthIndex++;
            UpdateHealth();
        }

        private void UpdateHealth()
        {
            _currentHealth = _healths[_healthIndex];
        }
    }
}