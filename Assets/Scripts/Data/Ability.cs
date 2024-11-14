using System;
using System.Collections.Generic;
using CustomData;
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
public struct AbilityData
{
    public EAbility type;
    public float initialValue;
    public float applyingValue; // 힘 n 당 1의 데미지를 얻기 등등으로 사용 예정
    public float improveValue; // 레벨 업할 때, 추가되는 능력치
}

public class Ability : MonoBehaviour
{
    public AbilityData[] initialData;
    public Dictionary<EAbility, PassiveStat> ability = new Dictionary<EAbility, PassiveStat>();
    public Dictionary<EAbility, float> applying = new Dictionary<EAbility, float>();
    
    private void Start()
    {
        DataManager.Instance.OnSave += Save;
        DataManager.Instance.OnLoadComplete += Initialize;

        DataManager.Instance.Level.OnLevelChanged += (level) =>
        {
            Improve();
        };

        foreach (var data in initialData)
        {
            applying.Add(data.type, data.applyingValue);
        }
    }
    
    public void Initialize()
    {
        if (DataManager.Instance.IsFirstAccess)
        {
            foreach (var data in initialData)
            {
                ability.Add(data.type, new PassiveStat(data.initialValue, 0f));
            }
        }
        else
        {
            foreach (var data in DataManager.Instance.PlayerData.ability)
            {
                ability.Add((EAbility)data.key, data.value);
            }
        }
    }

    public void Save()
    {
        DataManager.Instance.PlayerData.ability.Clear();
        foreach (var type in ability.Keys)
        {
            DataManager.Instance.PlayerData.ability.Add( new JsonDictionary<EAbility, PassiveStat>() { key = type, value = ability[type] });
        }
    }
    
    
    public void Add(EAbility type, float amount)
    {
        ability[type].Add(amount);
    }

    public void Subtract(EAbility type, float amount)
    {
        ability[type].Subtract(amount);
    }

    public void Improve()
    {
        foreach (var data in initialData)
        {
            ability[data.type].Improve(data.improveValue);
        }
    }
}
