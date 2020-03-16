using UnityEngine;
using Zenject;
using TMPro;

public class UIController : MonoBehaviour
{
    [Inject]
    private GameController gameController;

    [SerializeField] private TextMeshProUGUI CoutEnemy;
    [SerializeField] private TextMeshProUGUI CoutTrap;
    [SerializeField] private TextMeshProUGUI TurnCoutEnemy;
    [SerializeField] private TextMeshProUGUI TurnCoutTrap;

    private GameObject PanelForTest;
    private GameObject PanelGameLog;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) PanelGameLog.SetActive(!PanelGameLog.active);
        if (Input.GetKeyDown(KeyCode.J)) PanelForTest.SetActive(!PanelForTest.active);
    }

    public void SetCoutEnemy(string value)
    {
        CoutEnemy.text = $"Cout <color=#008080ff>enemy</color> : <color=red>{value}</color>";
    }

    public void SetCoutTrap(string value)
    {
        CoutTrap.text = $"Cout <color=#008080ff>Trap</color> : <color=red>{value}</color>";
    }

    public void SetTurnCoutEnemy(string value)
    {
        TurnCoutEnemy.text = $"Death <color=#008080ff>enemy</color> : <color=red>{value}</color>";
    }

    public void SetTurnCoutTrap(string value)
    {
        TurnCoutTrap.text = $"Death <color=#008080ff>Trap</color> : <color=red>{value}</color>";
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