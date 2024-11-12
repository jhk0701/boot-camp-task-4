using System;
using UnityEngine;

[Serializable]
public class ConsumeEffect
{
    public EStatus type;
    public float value;
}

[CreateAssetMenu(fileName ="New Consume", menuName = "New Consume")]
public class ConsumableItemData : ItemData
{

    public bool canStack = true;
    public int maxStackCount = 999;
    
    [Header("Consumable Item")]
    public ConsumeEffect[] effects;
}