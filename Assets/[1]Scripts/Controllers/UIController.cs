using UnityEngine;
using Zenject;
using TMPro;

public class UIController : MonoBehaviour
{
    [Inject]
    private GameController gameController;

    [SerializeField] private TextMeshProUGUI CoutEnemy;

    private GameObject PanelForTest;
    private GameObject PanelGameLog;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) PanelGameLog.SetActive(!PanelGameLog.active);
        if (Input.GetKeyDown(KeyCode.J)) PanelForTest.SetActive(!PanelForTest.active);
    }

    public void SetCoutEnemy(string value)
    {
        CoutEnemy.text = $"Cout enemy : {value}";
    }

    public void ShowAllPanel()
    {
        PanelForTest.SetActive(true);
    }

    public void HideAllPanel()
    {
        PanelForTest.SetActive(false);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        PanelForTest = transform.Find("PanelTest").gameObject;
        PanelGameLog = transform.Find("PanelGameLog").gameObject;
    }
#endif
}