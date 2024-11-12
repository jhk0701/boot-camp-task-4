using System;

public class ShoppingSlot : Slot
{
    MerchantData merchant; // 데이터받기

    public void Initialize(int id, MerchantData dataSet, Action<int> selectedAction)
    {
        merchant = dataSet;
        base.Initialize(id, selectedAction);
    }

    public override void Set()
    {
        if(index >= merchant.itemsOnSale.Length)
        {
            Clear();
            return;   
        }

        ItemData data = merchant.itemsOnSale[index];
        icon.sprite = data.icon;
    }
}
