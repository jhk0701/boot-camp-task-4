using System;
using System.Text;
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

    public override string GetItemInfo()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < effects.Length; i++)
        {
            sb.Append($"{effects[i].type} : {effects[i].value}");
        }

        return sb.ToString();
    }
}