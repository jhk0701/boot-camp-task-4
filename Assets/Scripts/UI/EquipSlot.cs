using System;

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
        EquipableItemData data;
        if (!equipment.equipments.TryGetValue(type, out data) || data == null)
        {
            Clear();
            return;
        }

        icon.sprite = data.icon;
        quantityText.text = ""; // TODO : 업그레이드 정보

        // Item item = inventory.items[index];
        // icon.sprite = item.data.icon;
        // quantityText.text = item.quantity.ToString();
    }
}
