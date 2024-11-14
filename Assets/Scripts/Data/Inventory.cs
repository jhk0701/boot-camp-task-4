using System;
using UnityEngine;

[Serializable]
public class Item
{
    public ItemData data;
    public int quantity = 0;
    public int grade = 0;
}


public class Inventory : MonoBehaviour
{
    public Item[] items = new Item[CustomData.Constants.INVENTORY_MAX_SIZE];
    public event Action<int> OnChanged;

    private void Start()
    {
        DataManager.Instance.OnSave += Save;
        DataManager.Instance.OnLoadComplete += Initialize;
    }

    public void Initialize()
    {
        items = DataManager.Instance.PlayerInventory.inventory;
    }

    void Save()
    {
        DataManager.Instance.PlayerInventory.inventory = items;
    }

    public void AddItem(Item itemToAdd)
    {
        int index = -1;
        if (CanStack(itemToAdd.data))
        {
            Item item = FindItemForStack(itemToAdd.data as ConsumableItemData, out index);
            if (item != null)
            {
                item.quantity++;
                OnChanged?.Invoke(index);

                return;
            }
        }

        Item empty = FindEmpty(out index);
        if (empty != null)
        {
            empty.data = itemToAdd.data;
            empty.quantity++;

            OnChanged?.Invoke(index);
            return;
        }
        
        DisassembleItem(itemToAdd.data);
    }


    Item FindItemForStack(ConsumableItemData data, out int index)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].data == null) continue;

            if (items[i].data == data &&
                items[i].quantity < data.maxStackCount)
            {
                index = i;
                return items[i];
            }
        }

        index = -1;
        return null;
    }


    Item FindEmpty(out int index)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].data == null)
            {
                index = i;
                return items[i];
            }
        }

        index = -1;
        return null;
    }

    public void DisassembleItem(ItemData data)
    {
        DataManager.Instance.Property.Earn(EProperty.Jewelry, data.jewerlyWhenDisassembled);
    }    


    public bool RemoveItem(int index, int amount = 1)
    {
        Item item = items[index];

        if (item.quantity < amount)
            return false;

        if (CanStack(item.data))
        {
            item.quantity -= amount;

            if(item.quantity <= 0)
            {
                // TODO : 최적화가 필요할 듯 
                items[index] = new Item();
                // item.data = null;
                // item.quantity = 0;
            }
        }
        else
        {
            // TODO : 최적화가 필요할 듯 
            items[index] = new Item();
            // item.data = null;
            // item.quantity = 0;
        }

        OnChanged?.Invoke(index);
        return true;
    }


    bool CanStack(ItemData data)
    {
        return data is ConsumableItemData && (data as ConsumableItemData).canStack;
    }
}