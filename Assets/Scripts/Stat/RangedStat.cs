using System;
using UnityEngine;

[Serializable]
public class RangedStat : Stat
{
    public override float Value 
    { 
        get => base.Value; 
        protected set 
        {
            baseValue = value; 
            CallOnValueChangeEvent(Value, max);
        }
    }

    [SerializeField] public float max;
    [SerializeField] public float min;

    public RangedStat(float initValue, float maxValue)
    {
        Value = initValue;
        max = maxValue;
    }


    public override void Add(float amount)
    {
        Value = Mathf.Min(Value + amount, max);
    }

    public override void Subtract(float amount)
    {
        Value = Mathf.Max(Value - amount, min);
    }

    
}