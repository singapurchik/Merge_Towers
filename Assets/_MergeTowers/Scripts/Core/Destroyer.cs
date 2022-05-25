using UnityEngine;

namespace MT.Core
{
    public class Destroyer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}