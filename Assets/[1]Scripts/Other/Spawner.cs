using UnityEngine;

public class Spawner
{
    private IMessage iMessage; // TODO: don't forget to remove me!!

    readonly EnemyView.Factory EnemyFactory;
    readonly HeroView.Factory HeroFactory;

    public Spawner(IMessage newComponent, EnemyView.Factory enemyFactory, HeroView.Factory heroFactory)
    {
        iMessage = newComponent;
        EnemyFactory = enemyFactory;
        HeroFactory = heroFactory;
    }

    public void StartSpawner()
    {
        SpawnPlayer();
        SpawnEnemy(GetRandomAmount(1, 5));
    }

    private int GetRandomAmount(int minimum, int maximum)
    {
        return Random.Range(minimum, maximum);
    }

    public void SpawnPlayer()
    {
        iMessage.MessageOne("SpawnPlayer");
        var newHero = HeroFactory.Create();
        newHero.NewPosition(GetRandomStartPosition(-5, 5));
    }

    public void SpawnEnemy(int amount)
    {
        iMessage.MessageOne($"SpawnEnemy, amount - {amount}");
        if (amount <= 0) amount = 1;
        for (int i = 0; i < amount; i++)
        {
            var newEnemy = EnemyFactory.Create();
            newEnemy.NewPosition(GetRandomStartPosition(-5, 5));
        }
    }

    private Vector3 GetRandomStartPosition(int minimum, int maximum)
    {
        Vector3 newTransform;
        newTransform = new Vector3(Random.Range(minimum, maximum), Random.Range(minimum, maximum), Random.Range(minimum, maximum));
        return newTransform;
    }
}