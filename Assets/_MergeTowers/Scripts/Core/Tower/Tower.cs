using MT.Presenters;
using UnityEngine;
using Zenject;

namespace MT.Core
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(TowerSkinChanger))]
    [RequireComponent(typeof(CharacterSpawner))]
    [RequireComponent(typeof(Health))]
    public class Tower : MonoBehaviour, IGrabalable, IKillable
    {

        [SerializeField] private Transform _body;
        [Range(1, 5)] [SerializeField] private int _level;
        [SerializeField] private bool _interactable;
        [SerializeField] private ParticleSystem _hitVfx;

        private Game _game;
        private Health _health;
        private TowerView _view;
        private TowerMover _mover;
        private TowerPlacer _placer;
        private BoxCollider _boxCollider;
        private ISkinChanger _skinChanger;
        private TowerAnimator _animator;
        private CharacterSpawner _characterSpawner;
        private ButtonPresenter _buttonPresenter;
        public int Level => _level;

        private int _maxLevel = 5;
        private bool _selected;

        [Inject]
        public void Constructor(Game game, ButtonPresenter buttonPresenter)
        {
            _game = game;
            _buttonPresenter = buttonPresenter;
        }

        private void OnDisable()
        {
            if(_buttonPresenter != null)
                _buttonPresenter.Start -= _characterSpawner.GameStarted;

            if (_health != null)
            {
                _health.Died -= Kill;
                _health.GetDamage -= DamageImpact;
            }
        }

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _skinChanger = GetComponent<ISkinChanger>();
            _characterSpawner = GetComponent<CharacterSpawner>();
            _health = GetComponent<Health>();

            _characterSpawner.Initialize(_level);
            _health.Initialize(_level);
            _skinChanger.CreateSkinList();
            _skinChanger.ChangeSkinOn(_level);
            _mover = new TowerMover(transform);
            _placer = new TowerPlacer(transform);
            _view = new TowerView(_body);
            _animator = new TowerAnimator(_body);
            
            _buttonPresenter.Start += _characterSpawner.GameStarted;
            _game.GameFinished += _characterSpawner.GameOver;
            _health.GetDamage += DamageImpact;
            _health.Died += Kill;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out OnBoardPlace towerPlace))
                _placer.SetNewPlace(towerPlace);

            if (other.TryGetComponent(out Tower tower))
                Merge(tower);
        }

        private void Update()
        {
            if (_selected)
                _mover.Move();
        }

        public void Grab()
        {
            if(!_interactable) return;
            _selected = true;
            _characterSpawner.towerSelected = _selected;
            _mover.SetOriginalPos();
            _view.UpBody();
            _mover.SetMoveValues();
        }

        public void Release()
        {
            if(this == null || !_interactable) return;
            _selected = false;
            _characterSpawner.towerSelected = _selected;
            _mover.MoveToOriginalPos();
            _view.DownBody();
        }
        
        public void Kill()
        {
            _hitVfx.Play();
            _boxCollider.enabled = false;
            _placer.RemoveCurrentPlace();
            _body.gameObject.SetActive(false);
            _characterSpawner.enabled = false;
            enabled = false;
        }

        public void LevelUp()
        {
            _animator.Bounce();
            _level++;
            _health.LevelUp();
            _skinChanger.ChangeSkinOn(_level);
            _characterSpawner.UpCharacterLevel();
        }

        private void Merge(Tower tower)
        {
            if(!tower._interactable || tower._level == _maxLevel) return;
            if (_selected && _level == tower._level)
            {
                tower.LevelUp();
                _health.Kill();
            }

            if (PlayerPrefsController.CurrentLevel == 2)
                EventManager.TriggerEvent(CustomEventType.FirstMerge, null);
        }

        private void DamageImpact()
        {
            _hitVfx.Play();
            _animator.Shake();
        }
        
        public class Factory : PlaceholderFactory<Game, ButtonPresenter, Tower>{}
    }
}
