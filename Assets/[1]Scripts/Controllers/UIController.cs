using System.Collections;
using Zenject;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Inject]
    private GameController gameController;

    [SerializeField] private GameObject PanelForTest;

    private void OnValidate()
    {
        PanelForTest = transform.FindChild("PanelTest").gameObject;
    }

    public void ShowAllPanel()
    {
        PanelForTest.SetActive(true);
    }

    public void HideAllPanel()
    {
        PanelForTest.SetActive(false);
    }
}