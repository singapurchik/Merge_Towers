using UnityEngine;

namespace MT.Core
{
    public class CharacterMover : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;

        private Vector3 _localForward;

        public void Initialize()
        {
            _localForward = transform.worldToLocalMatrix.MultiplyVector(transform.forward);
        }

        public void MoveForward()
        {
            transform.Translate(_localForward * (_speed * Time.deltaTime));
        }
    }
}