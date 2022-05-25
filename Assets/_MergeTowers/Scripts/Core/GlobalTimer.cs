using UnityEngine;

namespace MT.Core
{
    public class GlobalTimer
    {
        public float timer;

        public void IncreaseTimer()
        {
            timer += Time.deltaTime;
        }

        public void ResetTimer()
        {
            timer = 0;
        }
    }
}
