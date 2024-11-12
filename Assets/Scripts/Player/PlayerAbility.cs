using System;
using System.Collections.Generic;
using UnityEngine;

public enum EAbility
{
    Strength,   // 데미지, 공격력
    Defense,    // 방어력, 가드 확룔
    Dexterity,  // 속력
    // Critical,    // 크리티컬 확률
    // Resistance   // 저항
}


public class PlayerAbility : MonoBehaviour
{
    public Dictionary<EAbility, Stat> ability = new Dictionary<EAbility, Stat>();
    Dictionary<EAbility, float> applying = new Dictionary<EAbility, float>();

    void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        // TODO : 데이터 받아올 것
        Player player = GetComponent<Player>();
        foreach (AbilityData data in player.data.ability)
        {
            ability.Add(data.type, new PassiveStat(data.initialValue, 0f));
            applying.Add(data.type, data.applyingValue);
        }
    }

    public void AddAbility(EAbility type, float amount)
    {
        ability[type].Add(amount);
    }

    public void SubtractAbility(EAbility type, float amount)
    {
        ability[type].Subtract(amount);
    }

    public float GetValue(EAbility type)
    {
        if (ability.TryGetValue(type, out Stat stat))
        {
            return stat.Value / applying[type]; // 적용치 적용
        }
        else
            return 0f;
    }

}