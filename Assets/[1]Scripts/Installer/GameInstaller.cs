using Zenject;

public class GameInstaller : MonoInstaller
{
    [Inject] private ScrObjPrefabs Prefabs;

    public override void InstallBindings()
    {
        InstallOther();
        InstallMessange();
        InstallEnemy();
        InstallPlayer();
        InstallSpawner();
    }

    private void InstallOther()
    {
        Container.Bind(typeof(IMessage), typeof(ITickable))
            .To<Message>()
            .AsSingle();
    }

    private void InstallMessange()
    {
        Container.Bind<string>().FromInstance("Hello World!");
        Container.Bind<Greeter>().AsSingle().NonLazy();
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
    private IMessage message;

    [Inject]
    public Greeter(IMessage getMessage, string newMessage)
    {
        message = getMessage;
        message.MessageTwo(newMessage);
    }
}