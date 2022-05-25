using MT.Core;
using MT.Presenters;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Game _game;
    [SerializeField] private ButtonPresenter _buttonPresenter;
    [SerializeField] private Tower _towerPrefab;
    
    public override void InstallBindings()
    {
        Container.Bind<Game>().FromInstance(_game);
        Container.Bind<ButtonPresenter>().FromInstance(_buttonPresenter);
        
        Container.BindFactory<Game, ButtonPresenter, Tower, Tower.Factory>().FromComponentInNewPrefab(_towerPrefab);
    }

    private void Awake()
    {
        _game.GameFinished += DisableContext;
    }

    private void DisableContext()
    {
        _game.GameFinished -= DisableContext;
        Destroy(gameObject);
    }
}