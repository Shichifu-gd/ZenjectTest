using UnityEngine.UI;
using UnityEngine;

public class PlayerBar : MonoBehaviour
{
    [SerializeField] private Image ImageHealthBar;

    private int LocalMaxHealth;

    public void AssignValues(int maxHealth)
    {
        LocalMaxHealth = maxHealth;
    }

    public void SetHealthBar(int health)
    {
        float num = health;
        ImageHealthBar.fillAmount = num / LocalMaxHealth; // TODO: add coroutine
    }
}