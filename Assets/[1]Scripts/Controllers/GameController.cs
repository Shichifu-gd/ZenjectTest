using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;
using Zenject;

public class GameController : MonoBehaviour
{
    [Inject] public UIController uIController;
    [Inject] private Spawner spawner;
    [Inject] private TurnOfRespawn turnOfRespawn;

    [SerializeField]
    private float EndTime = 5;
    private float CurrentTime;

    public bool CanMove { get; set; }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) Restart();
        if (CurrentTime >= EndTime) AllRespawn();
        else CurrentTime += Time.deltaTime;
    }

    public void StartGame()
    {
        StartSpawn();
    }

    private void StartSpawn()
    {
        spawner.StartSpawner();
    }

    private void AllRespawn()
    {
        turnOfRespawn.UnregisterGOTrap();
        turnOfRespawn.UnregisterGOEnemy();
        CurrentTime = 0;
    }

    public void Exit()
    {
        EditorApplication.isPaused = true;
        // Restart();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}