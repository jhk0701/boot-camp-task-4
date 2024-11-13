using System;
using System.Collections.Generic;
using CustomData;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string playerName;
    
    public int level;
    public float experience;
    
    // 필요하면 그때 분리하기
    public List<JsonDictionary<EStatus, RangedStat>> status;
    public List<JsonDictionary<EAbility, PassiveStat>> ability;
    public List<JsonDictionary<EProperty, PositiveValue>> property;
}

[Serializable]
public class PlayerInventory
{
    public Item[] inventory;
    public List<JsonDictionary<EEquipment, EquipableItemData>> equipment;
}