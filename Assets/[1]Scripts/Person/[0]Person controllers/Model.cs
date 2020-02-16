using UnityEngine;
using System;

[System.Serializable]
public class Model
{
    public event Action OnDeath;
    public event Action<int, int> OnHealthChanged;

    public int HealthBase;
    public int HealthCurrent;

    public void SetModel(ScrObjModel scrObjModel)
    {
        HealthBase = scrObjModel.Health;
        HealthCurrent = HealthBase;
    }

    public void ResiveDemage(int damage)
    {
        HealthCurrent -= damage;
        if (HealthCurrent > 0) OnHealthChanged?.Invoke(HealthCurrent, HealthBase);
        else OnDeath?.Invoke();
    }
}