using UnityEngine;
using Zenject;

public class TrapView : MonoBehaviour
{
    private Trap trap;
    private TurnOfRespawn respawn;

    [Inject]
    public void Construct(TurnOfRespawn turnOfRespawn) { respawn = turnOfRespawn; }

    private void Awake()
    {
        trap = new Trap();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var person = collision.gameObject.GetComponent<Person>();
        if (person != null)
        {
            trap.TrapActivation(person);
            respawn.RegisterGOTrap(gameObject);
        }
    }

    public void NewPosition(Vector3 transform)
    {
        gameObject.transform.position = transform;
    }

    public class Factory : PlaceholderFactory<TrapView> { }
}

public class Trap
{
    public void TrapActivation(Person person)
    {
        var entity = person;
        var damage = 0;
        if (entity != null)
        {
            if (person.GetComponentInChildren<HeroView>())
            {
                damage = 1;
                person.TakeDamage(damage);
            }
            if (person.GetComponentInChildren<EnemyView>())
            {
                damage = 2;
                person.TakeDamage(damage);
            }
        }
    }
}