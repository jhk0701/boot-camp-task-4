using System;
using System.Collections.Generic;
using CustomData;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public Dictionary<EEquipment, EquipableItemData> equipments = new Dictionary<EEquipment, EquipableItemData>();
    public event Action<EEquipment> OnEquipItem;
    public event Action<EEquipment> OnUnequipItem;
    
    private void Start()
    {
        DataManager.Instance.OnSave += Save;
        DataManager.Instance.OnLoadComplete += Initialize;
    }
    
    public void Initialize()
    {
        foreach (var item in DataManager.Instance.PlayerInventory.equipment)
        {
            equipments.Add((EEquipment)item.key, item.value);
        }
    }

    void Save()
    {
        DataManager.Instance.PlayerInventory.equipment.Clear();
        foreach (var type in equipments.Keys)
        {
            DataManager.Instance.PlayerInventory.equipment.Add(new JsonDictionary<EEquipment, EquipableItemData>(){key = type, value = equipments[type]});
        }
    }
    
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