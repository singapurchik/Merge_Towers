using UnityEngine;

namespace MT.Core
{
    public class CharacterEffects : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _bloodVFX;
        [SerializeField] private ParticleSystem _coinVFX;
        
        public void BloodVFX()
        {
            _bloodVFX.Play();
        }
        
        public void CoinVFX()
        {
            _coinVFX.Play();
        }
    }
}