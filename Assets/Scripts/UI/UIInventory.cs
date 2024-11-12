using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIModal
{
    [SerializeField] Transform slotContainer;
    [SerializeField] ItemSlot[] slots;

    void Awake()
    {
        slots = new ItemSlot[slotContainer.childCount];
        for (int i = 0; i < slotContainer.childCount; i++)
        {
            slots[i] = slotContainer.GetChild(i).GetComponent<ItemSlot>();
            slots[i].Initialize(i, (index)=>{});

            slots[i].Set();
        }
    }

    public override void Initialize()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        foreach(ItemSlot slot in slots)
        {
            slot.Set();
        }
    }


}
