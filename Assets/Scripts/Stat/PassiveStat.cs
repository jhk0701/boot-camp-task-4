using System;
using UnityEngine;

[Serializable]
public class AbilityStat : Stat
{
    public override float Value 
    { 
        get => base.Value + passiveValue; 
        protected set => base.Value = value; 
    }

    [SerializeField] float passiveValue = 0f;

    public override void Add(float amount)
    {
        passiveValue += amount;
    }

    public override void Subtract(float amount)
    {
        passiveValue = Mathf.Max(passiveValue - amount, 0f);
    }
}