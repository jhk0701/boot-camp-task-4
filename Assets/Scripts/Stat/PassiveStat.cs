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
        get => base.Value + _passiveValue; 
        protected set => base.Value = value; 
    }

    [SerializeField] float _passiveValue = 0f;
    public EAbility type;

    public override void Add(float amount)
    {
        _passiveValue += amount;
    }

    public override void Subtract(float amount)
    {
        _passiveValue = Mathf.Max(_passiveValue - amount, 0f);
    }
}