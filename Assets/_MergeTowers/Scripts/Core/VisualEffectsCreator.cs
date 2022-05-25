using System.Collections.Generic;
using UnityEngine;

namespace MT.Core
{
    public class VisualEffectsCreator : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _effect;

        public void PlayEffect()
        {
            _effect.Play();
        }
    }
}
