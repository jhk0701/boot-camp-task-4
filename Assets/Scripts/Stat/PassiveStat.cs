using System;
using UnityEngine;


[Serializable]
public class PassiveStat : Stat
{
    public override float Value 
    { 
        get => base.Value + passiveValue; 
        protected set 
        {
            base.Value = value;
            CallOnValueChangeEvent(Value, passiveValue); // 현재값 (+추가값) 형태로 사용
        } 
    }

    public float passiveValue;


    public PassiveStat(float initValue, float initPassive)
    {
        Value = initValue;
        passiveValue = initPassive;
    }
    

    public override void Add(float amount)
    {
        passiveValue += amount;
    }

    public override void Subtract(float amount)
    {
        passiveValue = Mathf.Max(passiveValue - amount, 0f);
    }

    public void Improve(float amount)
    {
        base.Value += amount;
    }
}