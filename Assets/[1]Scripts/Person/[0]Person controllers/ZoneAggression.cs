using UnityEngine;

public class ZoneAggression : MonoBehaviour
{
    private EnemyView enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<EnemyView>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HeroView>()) NewTarget(collision.GetComponent<HeroView>());
    }

    private void NewTarget(HeroView newTarget)
    {
        enemy.SetTarget(newTarget);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<HeroView>()) RemovesTarget();
    }

    private void RemovesTarget()
    {
        enemy.SetTarget(null);
    }
}