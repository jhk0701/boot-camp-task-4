using System;
using System.Collections.Generic;
using CustomData;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public Dictionary<EEquipment, Item> equipments = new Dictionary<EEquipment, Item>();
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
            DataManager.Instance.PlayerInventory.equipment.Add(new JsonDictionary<EEquipment, Item>(){key = type, value = equipments[type]});
        }
    }
    
    public void Equip(Item equipment)
    {
        EquipableItemData data = equipment.data as EquipableItemData;
        Unequip(data.type);

        equipments[data.type] = equipment;
        
        OnEquipItem?.Invoke(data.type);
    }

    public void Unequip(EEquipment type)
    {
        if (equipments.ContainsKey(type))
        {
            OnUnequipItem?.Invoke(type);
            
            equipments[type] = null;
        }
        else
            equipments.Add(type, new Item());
    }

    public void Upgrade(EEquipment type)
    {
        if (equipments.ContainsKey(type))
        {
            equipments[type].grade++;
        }
    }
    
}