using System.Collections;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Inject] private ScrObjPrefabs Prefabs;

    public override void InstallBindings()
    {
        InstallMessange();
        InstallOther();
        InstallEnemy();
        InstallPlayer();
        InstallSpawner();
    }

    private void InstallMessange()
    {
        Container.Bind<string>().FromInstance("Hello World!");
        Container.Bind<Greeter>().AsSingle().NonLazy();
    }

    private void InstallOther()
    {
        Container.Bind<IMessage>()
            .To<Message>()
            .AsSingle();
    }

    private void InstallEnemy()
    {
        Container.BindFactory<EnemyView, EnemyView.Factory>()
            .FromComponentInNewPrefab(Prefabs.EnemyPrefab)
            .UnderTransformGroup("Enemy");
    }

    private void InstallPlayer()
    {
        Container.BindFactory<HeroView, HeroView.Factory>()
           .FromComponentInNewPrefab(Prefabs.HeroPrefab);
    }

    private void InstallSpawner()
    {
        Container.Bind<Spawner>()
        .AsSingle();
    }
}

public class Greeter
{
    public Greeter(string message)
    {
        Debug.Log(message);
    }
}