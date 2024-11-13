using System;
using UnityEngine;

[Serializable]
public class Item
{
    public ItemData data;
    public int quantity = 0;
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

    public void AddItem(ItemData data)
    {
        int index = -1;
        if (CanStack(data))
        {
            Item item = FindItemForStack(data as ConsumableItemData, out index);
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
            empty.data = data;
            empty.quantity++;

            OnChanged?.Invoke(index);
            return;
        }
        
        //
        ThrowItem(data);
    }

    public Item FindItem(ItemData data)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].data == null) 
                continue;

            if (items[i].data == data)
                return items[i];
        }

        return null;
    }

    public Item FindItem(ItemData data, out int index)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].data == null) 
                continue;

            if (items[i].data == data)
            {
                index = i;
                return items[i];
            }
        }
        index = -1;
        return null;
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

    void ThrowItem(ItemData data)
    {
        Vector3 position = transform.position + Vector3.up + transform.forward * 0.5f;
        // Instantiate(data.dropPrefab, position, Quaternion.identity);
        Debug.Log("Item destroy");
    }    
    
    public void ThrowItem(int index)
    {
        ThrowItem(items[index].data);
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
                item.data = null;
                item.quantity = 0;
            }
        }
        else
        {
            item.data = null;
            item.quantity = 0;
        }

        OnChanged?.Invoke(index);
        return true;
    }


    bool CanStack(ItemData data)
    {
        return data is ConsumableItemData && (data as ConsumableItemData).canStack;
    }
}