using System;
using System.Collections.Generic;
using CustomData;
using UnityEngine;

public enum EProperty
{
    Gold, // 기본 화폐
    Jewelry, // 재화 유형 1 : 강화 재료
}

[Serializable]
public struct PropertyData
{
    public EProperty type;
    public ulong initialValue;
}

/// <summary>
/// 플레이어의 보유 자산 정보
/// 아이템 정보, 재산
/// </summary>
public class Property : MonoBehaviour
{
    public PropertyData[] initialData;
    public Dictionary<EProperty, PositiveValue> properties = new Dictionary<EProperty, PositiveValue>();

    private void Start()
    {
        DataManager.Instance.OnSave += Save;
        DataManager.Instance.OnLoadComplete += Initialize;
    }

    public void Initialize()
    {
        if (DataManager.Instance.IsFirstAccess)
        {
            foreach (var data in initialData)
            {
                properties.Add(data.type, new PositiveValue(data.initialValue));
            }
        }
        else
        {
            foreach (var property in DataManager.Instance.PlayerData.property)
            {
                properties.Add((EProperty)property.key, property.value);
            }    
        }
        
    }

    void Save()
    {
        DataManager.Instance.PlayerData.property.Clear();
        foreach (var type in properties.Keys)
        {
            DataManager.Instance.PlayerData.property.Add(new JsonDictionary<EProperty, PositiveValue>(){key = type, value = properties[type]});
        }
    }

    public void Earn(EProperty type, ulong amount)
    {
        properties[type].Add(amount);
    }
    
    public bool Pay(EProperty type, ulong amount)
    {
        if (properties[type].Value < amount) 
            return false;
        
        properties[type].Subtract(amount);
        return true;
    }
}