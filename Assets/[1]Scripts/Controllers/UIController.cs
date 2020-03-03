using System.Collections;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    [Inject]
    public GameController gameController;

    [SerializeField] private GameObject PanelForTest;

#if UNITY_EDITOR
    private void OnValidate()
    {
        PanelForTest = transform.Find("PanelTest").gameObject;
    }
#endif

    public void ShowAllPanel()
    {
        PanelForTest.SetActive(true);
    }

    public void HideAllPanel()
    {
        PanelForTest.SetActive(false);
    }
}