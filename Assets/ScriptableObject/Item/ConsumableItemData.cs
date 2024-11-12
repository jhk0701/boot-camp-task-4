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
    
    [Header("Consumable Item")]
    public ConsumeEffect[] effects;
}