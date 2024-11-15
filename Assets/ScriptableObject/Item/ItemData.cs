using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;

    public ulong price;
    public ulong jewerlyWhenDisassembled;

    public abstract string GetItemInfo();        
}