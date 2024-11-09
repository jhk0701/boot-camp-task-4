using System;
using UnityEngine;

[Serializable]
public class StatusStat : Stat
{
    [SerializeField] public float maxValue = 100f;
    [SerializeField] float minValue = 0f;

    public override void Add(float amount)
    {
        Value = Mathf.Min(Value + amount, maxValue);
    }

    public override void Subtract(float amount)
    {
        Value = Mathf.Max(Value - amount, minValue);
    }
}