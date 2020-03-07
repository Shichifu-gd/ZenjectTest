using UnityEngine.SceneManagement;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) Restart();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        EditorApplication.isPaused = true;
        // Restart();
    }
}