using System.Collections;
using Zenject;
using UnityEngine;
using UnityEditor;

public class GameController : MonoBehaviour
{
    [Inject] private GameObject HeroPre;

    public bool CanMove { get; set; }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        CreatePrefabs(HeroPre);
    }

    private void CreatePrefabs(GameObject prefab)
    {
        GameObject.Instantiate(prefab);
    }

    public void Restart()
    {

    }

    public void Exit()
    {
        EditorApplication.isPaused = true;
    }
}