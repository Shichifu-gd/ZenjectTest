using UnityEngine;
using System;

public class Person : MonoBehaviour
{
    public virtual event Action<int> OnTakeDamage;

    public virtual void HealthAnimation(int curhealth, int maxHealth) { }
    public virtual void Death() { }
}