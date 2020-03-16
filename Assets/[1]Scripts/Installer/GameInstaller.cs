using Zenject;

public class GameInstaller : MonoInstaller
{
    [Inject] private ScrObjPrefabs Prefabs;

    public override void InstallBindings()
    {
        InstallOther();
        InstallMessange();
        InstallSpawner();
        InstallEnemy();
        InstallPlayer();
    }

    private void InstallOther()
    {
        Container.Bind(typeof(IMessage), typeof(ITickable))
            .To<Message>()
            .AsSingle();
    }

    private void InstallMessange()
    {
        Container.Bind<string>().FromInstance("<color=#ff00ffff>System</color>: Hello World!");
        Container.Bind<Greeter>().AsSingle().NonLazy();
    }

    private void InstallEnemy()
    {
        Enemy();
        Trap();
    }

    private void Enemy()
    {
        Container.BindFactory<EnemyView, EnemyView.Factory>()
            .FromComponentInNewPrefab(Prefabs.EnemyPrefab)
            .UnderTransformGroup("Enemy");
    }

    private void Trap()
    {
        Container.BindFactory<TrapView, TrapView.Factory>()
          .FromComponentInNewPrefab(Prefabs.TrapPrefab)
          .UnderTransformGroup("Trap");
    }

    private void InstallPlayer()
    {
        Container.BindFactory<HeroView, HeroView.Factory>()
            .FromComponentInNewPrefab(Prefabs.HeroPrefab);
    }

    private void InstallSpawner()
    {
        Container.Bind<SpawnerSettings>()
           .AsSingle();

        Container.Bind<TurnOfRespawn>()
            .AsSingle();

        Container.Bind<Spawner>()
            .AsSingle();
    }
}

public class Greeter
{
    private IMessage message;

    [Inject]
    public Greeter(IMessage getMessage, string newMessage)
    {
        message = getMessage;
        message.MessageTwo(newMessage);
    }
}