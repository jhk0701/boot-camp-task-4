using System;
using System.Text;
using UnityEngine;

[Serializable]
public class ConsumeEffect
{
    public EStatus type;
    public float value;

    public void Use()
    {
        Debug.Log("Use called");
        //CharacterManager.Instance.Player.Status.RecoverStatus(type, value);
    }
}

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
            sb.Append($"{effects[i].type} : {effects[i].value}");
        }

        return sb.ToString();
    }
}