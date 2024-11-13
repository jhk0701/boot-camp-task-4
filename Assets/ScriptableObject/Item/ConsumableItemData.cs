using System;
using System.Text;
using UnityEngine;


[CreateAssetMenu(fileName ="New Consume", menuName = "New Consume")]
public class ConsumableItemData : ItemData
{
    public bool canStack = true;
    public int maxStackCount = 999;
    
    [Header("Consumable Item")]
    public ConsumeEffect[] effects;

    public override string GetItemInfo()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < effects.Length; i++)
        {
            sb.Append($"{effects[i].GetEffectInfo()}\n");
        }

        return sb.ToString();
    }
}