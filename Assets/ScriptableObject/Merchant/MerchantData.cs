using UnityEngine;

[CreateAssetMenu(fileName ="New Merchant Data", menuName = "New Merchant Data")]
public class MerchantData : ScriptableObject
{
    public string merchantName;

    public ItemData[] itemsOnSale;
}
