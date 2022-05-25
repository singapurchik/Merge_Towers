using System;
using System.Collections.Generic;
using UnityEngine;

namespace MT.Core
{
    public class Castle : MonoBehaviour
    {
        [SerializeField] private List<Health> _castleParts;
        [SerializeField] private HealthType _type;
        
        private int _destroyedPartCount;
        public event Action Destroyed;

        private void OnEnable()
        {
            foreach (var castlePart in _castleParts)
            {
                castlePart.Died += CheckOnDestroy;
            }
        }

        private void OnDisable()
        {
            foreach (var castlePart in _castleParts)
            {
                castlePart.Died -= CheckOnDestroy;
            }
        }

        private void CheckOnDestroy()
        {
            _destroyedPartCount++;
            if(_destroyedPartCount == _castleParts.Count)
                Destroyed?.Invoke();
        }
    }
}
