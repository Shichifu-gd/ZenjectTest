using UnityEngine;
using UnityEditor;
using Zenject;

public class GameController : MonoBehaviour
{
    [Inject] public UIController uIController;
    [Inject] private Spawner spawner;

    public bool CanMove { get; set; }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        StartSpawn();
    }

    private void StartSpawn()
    {
        spawner.StartSpawner();
    }

    public void Restart()
    {

    }

    public void Exit()
    {
        EditorApplication.isPaused = true;
    }
}