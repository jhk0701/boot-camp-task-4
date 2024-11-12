using System;

public class ItemSlot : Slot
{
    Inventory inventory;

    public override void Initialize(int id, Action<int> selectedAction)
    {
        inventory = DataManager.Instance.Inventory;

        base.Initialize(id, selectedAction);
    }

    public override void Set()
    {
        if(inventory.items[index].data == null)
        {
            Clear();
            return;
        }

        Item item = inventory.items[index];
        icon.sprite = item.data.icon;
        
        quantityText.gameObject.SetActive(!(item.data is EquipableItemData));
        quantityText.text = item.quantity.ToString();
        
    }

}
