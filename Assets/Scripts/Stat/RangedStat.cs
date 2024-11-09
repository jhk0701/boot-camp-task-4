using System;
using UnityEngine;

public enum EStatus
{
    Health,     // 체력
    Stamina,    // 스태미나
    Mana,       // 마나
}

[Serializable]
public class RangedStat : Stat
{
    [SerializeField] float _max = 100f;
    [SerializeField] float _min = 0f;
    public EStatus type;

    public override void Add(float amount)
    {
        Value = Mathf.Min(Value + amount, _max);
    }

    public override void Subtract(float amount)
    {
        Value = Mathf.Max(Value - amount, _min);
    }
}