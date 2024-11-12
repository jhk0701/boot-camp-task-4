using System.Collections.Generic;
using UnityEngine;

public class UIEquipment : UIModal
{
    [SerializeField] EquipSlot[] slots;
    Dictionary<EEquipment, EquipSlot> equipment;

    void Awake()
    {
        equipment = new Dictionary<EEquipment, EquipSlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Initialize((int)slots[i].type, SelectSlot);
            equipment.Add(slots[i].type, slots[i]);
        }
    }

    public override void Initialize()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Set();
        }
    }

    void SelectSlot(int id)
    {

    }
}