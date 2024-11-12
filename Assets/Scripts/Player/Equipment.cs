using System;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public Dictionary<EEquipment, EquipableItemData> equipments = new Dictionary<EEquipment, EquipableItemData>();
    public event Action<EEquipment> OnEquipItem;
    public event Action<EEquipment> OnUnequipItem;

    
    public void Equip(EquipableItemData equipment)
    {
        Unequip(equipment.type);

        equipments[equipment.type] = equipment;

        OnEquipItem?.Invoke(equipment.type);
    }

    public void Unequip(EEquipment type)
    {
        if (equipments.ContainsKey(type))
        {
            OnUnequipItem?.Invoke(type);
            
            equipments[type] = null;
        }
        else
            equipments.Add(type, null);
    }
}