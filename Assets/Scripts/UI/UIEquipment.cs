using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class UIEquipment : UIModal
{
    Equipment equipment;

    [SerializeField] Transform slotContainer;
    Dictionary<EEquipment, EquipSlot> equipSlot;

    [Header("Selected")]
    [SerializeField] GameObject selectOption;
    [SerializeField] TextMeshProUGUI selectedItemName;
    [SerializeField] TextMeshProUGUI selectedItemEffects;
    EEquipment selectedEquipment;
    
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

    private void OnDisable()
    {
        selectOption.SetActive(false);
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
        selectedEquipment = (EEquipment)id;
        if(!equipment.equipments.ContainsKey(selectedEquipment)) return;
        
        selectOption.SetActive(true);
        selectedItemName.text = equipment.equipments[selectedEquipment].data.itemName;
        selectedItemEffects.text = equipment.equipments[selectedEquipment].data.GetItemInfo();
    }

    public void OnClickUnequip()
    {
        if (equipment.equipments.TryGetValue(selectedEquipment, out Item item) && item != null)
        {
            DataManager.Instance.Inventory.AddItem(item);
            equipment.Unequip(selectedEquipment);
        }
        
        selectOption.SetActive(false);
    }

    public void OnClickUpgrade()
    {
        if (equipment.equipments.TryGetValue(selectedEquipment, out Item item) && item != null)
        {
            equipment.Upgrade((item.data as EquipableItemData).type);
            Debug.Log($"item upgrade : {item.grade}");
        }
    }
}