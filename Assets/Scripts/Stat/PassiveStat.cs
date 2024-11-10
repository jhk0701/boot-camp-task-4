using System;
using UnityEngine;

public enum EAbility
{
    Strength,   // 데미지, 공격력
    Defense,    // 방어력, 가드 확룔
    Dexterity,  // 속력
    // Critical,    // 크리티컬 확률
    // Resistance   // 저항
}

[Serializable]
public class PassiveStat : Stat
{
    public override float Value 
    { 
        get => base.Value + PassiveValue; 
        protected set 
        {
            base.Value = value;
            CallOnValueChangeEvent(Value, PassiveValue); // 현재값 (+추가값) 형태로 사용
        } 
    }
    
    public float PassiveValue { get; private set; }


    public PassiveStat(float initValue, float initPassive)
    {
        Value = initValue;
        PassiveValue = initPassive;
    }
    

    public override void Add(float amount)
    {
        PassiveValue += amount;
    }

    public override void Subtract(float amount)
    {
        PassiveValue = Mathf.Max(PassiveValue - amount, 0f);
    }
}