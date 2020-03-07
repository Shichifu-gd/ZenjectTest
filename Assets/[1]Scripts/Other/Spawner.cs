using UnityEngine;

public class Spawner
{
    private IMessage iMessage; // TODO: don't forget to remove me!!

    private UIController UI;

    readonly EnemyView.Factory EnemyFactory;
    readonly HeroView.Factory HeroFactory;

    public Spawner(IMessage newComponent, EnemyView.Factory enemyFactory, HeroView.Factory heroFactory, UIController uIController)
    {
        iMessage = newComponent;
        EnemyFactory = enemyFactory;
        HeroFactory = heroFactory;
        UI = uIController;
    }

    public void StartSpawner()
    {
        SpawnPlayer();
        SpawnEnemy(GetRandomAmount(1, 10));
    }

    public void SpawnPlayer()
    {
        iMessage.MessageOne("SpawnPlayer");
        var newHero = HeroFactory.Create();
        newHero.NewPosition(GetRandomStartPosition(-5, 5));
    }

    public void SpawnEnemy(int amount)
    {
        var CheckNumber = QuantityEnemyCheck(amount);
        for (int i = 0; i < amount; i++)
        {
            var newEnemy = EnemyFactory.Create();
            newEnemy.NewPosition(GetRandomStartPosition(-10, 10));
        }
    }

    private int QuantityEnemyCheck(int amount)
    {
        iMessage.MessageOne($"SpawnEnemy, amount - {amount}");
        if (amount <= 0) amount = 1;
        UI.SetCoutEnemy(amount.ToString());
        return amount;
    }

    private Vector3 GetRandomStartPosition(int minimum, int maximum)
    {
        Vector3 newTransform;
        var x = GetRandomAmount(minimum, maximum);
        var y = GetRandomAmount(minimum, maximum);
        var z = GetRandomAmount(minimum, maximum);
        newTransform = new Vector3(x, y, z);
        return newTransform;
    }

    private int GetRandomAmount(int minimum, int maximum) { return Random.Range(minimum, maximum); }
}