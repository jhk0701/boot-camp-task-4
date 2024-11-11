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

    void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        // TODO : 데이터 받아올 것
        Player player = GetComponent<Player>();
        foreach (AbilityConfig config in player.config.abilityConfigs)
        {
            ability.Add(config.type, new PassiveStat(config.initialValue, 0f));   
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

}