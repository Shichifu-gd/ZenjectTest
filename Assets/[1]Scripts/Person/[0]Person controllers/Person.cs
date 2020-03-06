using UnityEngine;
using System;

public class Person : MonoBehaviour
{
    public virtual event Action<int> OnTakeDamage;
    //  public virtual void Contact(GameObject contact) { }
    public virtual void HealthAnimation(int curHealth) { }
    public virtual void Death() { }
}