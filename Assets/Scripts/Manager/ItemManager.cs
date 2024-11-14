using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public ConsumableItemData[] consumables;
    public EquipableItemData[] equipments;
}
