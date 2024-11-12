using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingSlot : Slot
{
    MerchantData merchant;

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
