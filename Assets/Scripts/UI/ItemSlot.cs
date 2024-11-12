using System;

public class ItemSlot : Slot
{
    Inventory inventory;

    public override void Initialize(int id, Action<int> selectedAction)
    {
        // 음... 더 좋은 방법이 필요할 거 같음
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
        quantityText.text = item.quantity.ToString();
    }

}
