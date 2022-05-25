using UnityEngine;

namespace MT.Core
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimator : MonoBehaviour
    {
        private Animator _animator;

        private static readonly int Fight = Animator.StringToHash("fight");
        private static readonly int Win = Animator.StringToHash("win");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void FightAnim()
        {
            _animator.SetBool(Fight, true);
        }

        public void MoveAnim()
        {
            _animator.SetBool(Fight, false);
        }

        public void WinAnim()
        {
            _animator.SetTrigger(Win);
        }

        public void DisableAnimator()
        {
            _animator.enabled = false;
            enabled = false;
        }
    }
}