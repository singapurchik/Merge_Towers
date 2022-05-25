using UnityEngine;

namespace MT.Core
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(VisualEffectsCreator))]
    public class CastlePart : MonoBehaviour
    {
        private Health _health;
        private TowerAnimator _animator;
        private BoxCollider _boxCollider;
        private VisualEffectsCreator _effectsCreator;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _boxCollider = GetComponent<BoxCollider>();
            _effectsCreator = GetComponent<VisualEffectsCreator>();
            _animator = new TowerAnimator(transform);
            _health.Initialize(1);

            _health.GetDamage += DamageImpact;
            _health.Died += DestroyCastle;
        }

        private void OnDisable()
        {
            if (_health == null) return;
            _health.GetDamage -= DamageImpact;
            _health.Died -= DestroyCastle;
        }
        
        private void DamageImpact()
        {
            _effectsCreator.PlayEffect();
            _animator.Shake();
        }

        private void DestroyCastle()
        {
            _effectsCreator.PlayEffect();
            _boxCollider.enabled = false;
            _health.enabled = false;
            gameObject.SetActive(false);
            enabled = false;
        }
    }
}