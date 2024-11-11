using System;
using UnityEngine;

public enum EStatus
{
    Health,
    Stamina,
    Mana,
}

[Serializable]
public class RangedStat : Stat
{
    public override float Value 
    { 
        get => base.Value; 
        protected set 
        {
            base.Value = value; 
            CallOnValueChangeEvent(Value, Max);
        }
    }

    [field:SerializeField] public float Max { get; private set; }
    public float Min { get; private set; } = 0f;


    public RangedStat(float initValue, float maxValue)
    {
        Value = initValue;
        Max = maxValue;
    }


    public override void Add(float amount)
    {
        Value = Mathf.Min(Value + amount, Max);
    }

    public override void Subtract(float amount)
    {
        Value = Mathf.Max(Value - amount, Min);
    }

    
}