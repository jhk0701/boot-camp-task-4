using System;
using UnityEngine;

public enum EEquipment
{
    Weapon,
    Head,
    Top,
    Bottom,
    Foot,
}

[Serializable]
public class EquipEffect
{
    public EAbility type;
    public float value;
}

[CreateAssetMenu(fileName ="New Equipment", menuName = "New Equipment")]
public class EquipableItemData : ItemData
{
    
    [Header("Equipable Item")]
    public EEquipment type;
    public EquipEffect[] effects;
}