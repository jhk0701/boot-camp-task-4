using System;
using UnityEngine;

public class EquipSlot : Slot
{    
    Equipment equipment;
    public EEquipment type;

    public override void Initialize(int id, Action<int> selectedAction)
    {
        equipment = DataManager.Instance.Equipment;

        type = (EEquipment)id;

        base.Initialize(id, selectedAction);
    }
    
    public override void Set()
    {
        
        // Item item = inventory.items[index];
        // icon.sprite = item.data.icon;
        // quantityText.text = item.quantity.ToString();
    }
}
