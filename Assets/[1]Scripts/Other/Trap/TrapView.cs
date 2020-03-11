using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrapView : MonoBehaviour
{
    private Trap trap;

    private void Awake()
    {
        trap = new Trap();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var person = collision.GetComponent<Person>();
        trap.TrapActivation(person);
    }
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