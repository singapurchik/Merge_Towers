namespace MT.Core
{
    public class CharacterData
    {
        private readonly float _timeBeforeChangeTarget = 0.5f;
        private readonly float _minInitializeDelay = 0.5f;
        private readonly float _maxInitializeDelay = 1f;

        public float TimeBeforeChangeTarget => _timeBeforeChangeTarget;
        public float MinInitializeDelay => _minInitializeDelay;
        public float MaxInitializeDelay => _maxInitializeDelay;
    }
}