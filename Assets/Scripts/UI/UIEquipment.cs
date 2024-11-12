using System.Collections.Generic;
using UnityEngine;

public class UIEquipment : UIModal
{
    Equipment equipment;

    [SerializeField] EquipSlot[] slots;
    Dictionary<EEquipment, EquipSlot> equipSlot;

    void Awake()
    {
        equipment = DataManager.Instance.Equipment;

        equipSlot = new Dictionary<EEquipment, EquipSlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Initialize((int)slots[i].type, SelectSlot);
            equipSlot.Add(slots[i].type, slots[i]);

            slots[i].Clear();
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
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Set();
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