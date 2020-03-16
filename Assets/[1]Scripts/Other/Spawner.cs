using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Spawner
{
    [SerializeField] private SpawnerSettings Settings;

    private IMessage iMessage;

    private UIController UI;

    readonly EnemyView.Factory EnemyFactory;
    readonly HeroView.Factory HeroFactory;
    readonly TrapView.Factory TrapFactory;

    public Spawner(
        IMessage newComponent,
        EnemyView.Factory enemyFactory,
        HeroView.Factory heroFactory,
        TrapView.Factory trapFactory,
        UIController uIController,
        SpawnerSettings spawnerSettings)
    {
        iMessage = newComponent;
        EnemyFactory = enemyFactory;
        HeroFactory = heroFactory;
        TrapFactory = trapFactory;
        UI = uIController;
        Settings = spawnerSettings;
    }

    public void StartSpawner()
    {
        SpawnPlayer();
        SpawnEnemy(Settings.GetAmountEnemy());
        SpawnTrap(Settings.GetAmountTrap());
    }

    public void SpawnPlayer()
    {
        iMessage.MessageOne("<color=#ff00ffff>System</color>: SpawnPlayer");
        var newHero = HeroFactory.Create();
        newHero.NewPosition(GetPosition.GetRandomStartPosition(-5, 5));
    }

    public void SpawnEnemy(int amount)
    {
        QuantityEnemyCheck(amount);
        for (int i = 0; i < amount; i++)
        {
            var newEnemy = EnemyFactory.Create();
            newEnemy.NewPosition(GetPosition.GetRandomStartPosition(-10, 10));
        }
    }

    public void SpawnTrap(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var newTrap = TrapFactory.Create();
            newTrap.NewPosition(GetPosition.GetRandomStartPosition(-10, 10));
        }
        UI.SetCoutTrap(amount.ToString());
    }

    //delete
    private int QuantityEnemyCheck(int amount)
    {
        iMessage.MessageOne($"<color=#ff00ffff>System</color>: SpawnEnemy, amount - {amount}");
        if (amount <= 0) amount = 1;
        UI.SetCoutEnemy(amount.ToString());
        return amount;
    }
}

public class SpawnerSettings
{
    private Vector2 RangeEnemy;
    private Vector2 RangeTrap;

    public SpawnerSettings(ScrObjConfiguration configuration)
    {
        RangeEnemy = configuration.RangeEnemy;
        RangeTrap = configuration.RangeTrap;
    }

    public int GetAmountEnemy()
    {
        if (RangeEnemy.x < RangeEnemy.y && RangeEnemy.x != RangeEnemy.y) return GetRandomInt(RangeEnemy);
        return 0;
    }

    public int GetAmountTrap()
    {
        if (RangeTrap.x < RangeTrap.y && RangeTrap.x != RangeTrap.y) return GetRandomInt(RangeTrap);
        return 0;
    }

    private int GetRandomInt(Vector2 value)
    {
        int min = Convert.ToInt32(value.x);
        int max = Convert.ToInt32(value.y);
        return UnityEngine.Random.Range(min, max);
    }
}

public class TurnOfRespawn
{
    private UIController UI;

    private List<GameObject> GOTrap = new List<GameObject>();
    private List<GameObject> GOEnemy = new List<GameObject>();

    [Inject]
    public void Construct(UIController uIController)
    {
        UI = uIController;
    }

    public void RegisterGOTrap(GameObject trap)
    {
        GOTrap.Add(trap);
        trap.SetActive(false);
        UI.SetTurnCoutTrap((GOTrap.Count).ToString());
    }

    public void RegisterGOEnemy(GameObject enemy)
    {
        GOEnemy.Add(enemy);
        enemy.SetActive(false);
        UI.SetTurnCoutEnemy((GOEnemy.Count).ToString());
    }

    public void UnregisterGOTrap()
    {
        if (GOTrap.Count > 0)
        {
            var index = GOTrap.Count - 1;
            var go = GOTrap[index];
            var trap = go.GetComponent<TrapView>();
            GOTrap.RemoveAt(index);
            trap.NewPosition(GetPosition.GetRandomStartPosition(-10, 10));
            go.SetActive(true);
        }
        UI.SetTurnCoutTrap((GOTrap.Count).ToString());
    }

    public void UnregisterGOEnemy()
    {
        if (GOEnemy.Count > 0)
        {
            var index = GOEnemy.Count - 1;
            var go = GOEnemy[index];
            var enemy = go.GetComponent<EnemyView>();
            GOEnemy.RemoveAt(index);
            enemy.NewPosition(GetPosition.GetRandomStartPosition(-10, 10));
            go.SetActive(true);
        }
        UI.SetTurnCoutEnemy((GOEnemy.Count).ToString());
    }
}