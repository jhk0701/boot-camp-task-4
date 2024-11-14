using System;
using UnityEngine;
using System.Collections.Generic;
using CustomData;

public enum EStatus
{
    Health,
    Stamina,
    Mana,
}

[Serializable]
public struct StatusData
{
    public EStatus type;
    public float maximumValue;
    public float improveValue; // 레벨 업할 때, 추가되는 능력치
}

public class Status : MonoBehaviour
{
    public StatusData[] initialData;
    public Dictionary<EStatus, RangedStat> status = new Dictionary<EStatus, RangedStat>();

    private void Start()
    {
        DataManager.Instance.OnSave += Save;
        DataManager.Instance.OnLoadComplete += Initialize;

        DataManager.Instance.Level.OnLevelChanged += (level) =>
        {
            Improve();
        };
    }

    public void Initialize()
    {
        if (DataManager.Instance.IsFirstAccess)
        {
            foreach (var data in initialData)
            {
                status.Add(data.type, new RangedStat(data.maximumValue, data.maximumValue));
            }
        }
        else
        {
            foreach (var data in DataManager.Instance.PlayerData.status)
            {
                status.Add((EStatus)data.key, data.value);
            }
        }
    }

    public void Save()
    {
        DataManager.Instance.PlayerData.status.Clear();
        foreach (var type in status.Keys)
        {
            DataManager.Instance.PlayerData.status.Add(new JsonDictionary<EStatus, RangedStat>(){key = type, value = status[type]});
        }
    }
    
    public void Add(EStatus type, float amount)
    {
        status[type].Add(amount);
    }

    public void Subtract(EStatus type, float amount)
    {
        status[type].Subtract(amount);
    }

    public void Improve()
    {
        foreach (var data in initialData)
        {
            status[data.type].Improve(data.improveValue);
        }
    }
}