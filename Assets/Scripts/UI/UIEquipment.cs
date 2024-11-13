using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UIEquipment : UIModal
{
    Equipment equipment;

    [SerializeField] Transform slotContainer;
    Dictionary<EEquipment, EquipSlot> equipSlot;

    void Awake()
    {
        equipment = DataManager.Instance.Equipment;

        equipSlot = new Dictionary<EEquipment, EquipSlot>();

        
        for (int i = 0; i < slotContainer.childCount; i++)
        {
            EquipSlot slot = slotContainer.GetChild(i).GetComponent<EquipSlot>();
            slot.Initialize((int)slot.type, SelectSlot);
            equipSlot.Add(slot.type, slot);

            slot.Clear();
        }

        equipment.OnEquipItem += (type)=>
        {
            equipSlot[type].Set();
        };

        equipment.OnUnequipItem += (type)=>
        {
            equipSlot[type].Clear();
        };
    }

    public override void Initialize()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        var keys = equipSlot.Keys.ToArray();
        for (int i = 0; i < keys.Length; i++)
        {
            equipSlot[keys[i]].Set();
        }
    }

    void SelectSlot(int id)
    {
        // unequip
        EEquipment type = (EEquipment)id;
        EquipableItemData data;
        if (equipment.equipments.TryGetValue(type, out data) && data != null)
        {
            DataManager.Instance.Inventory.AddItem(data);
            equipment.Unequip(type);
        }
    }
}