using UnityEngine;
using TMPro;

public class UIShop : UIModal
{
    public MerchantData merchant;

    // TODO : 상인 품목에 따라 동적 생성하기
    Slot[] merchantSlot;
    Slot[] playerSlot;

    [SerializeField] Transform merchantSlotCotainer;
    [SerializeField] Transform playerSlotCotainer;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI playerGoldText;

    [Header("Selected")]
    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] TextMeshProUGUI itemEffectText;
    [SerializeField] TextMeshProUGUI itemPriceText;
    [SerializeField] GameObject buyButton;
    [SerializeField] GameObject sellButton;

    bool isBuying = false;
    int selectedIndex = -1;

    void Start()
    {
        // 캐릭터 재산 표시
        DataManager.Instance.Property.properties[EProperty.Gold].OnValueChange += (gold)=>
        {
            playerGoldText.text = string.Concat("보유 골드 :\n", gold.ToString(), " G");
        };
        ulong gold = DataManager.Instance.Property.properties[EProperty.Gold].Value;
        playerGoldText.text = string.Concat("보유 골드 :\n", gold.ToString(), " G");
    }

    public override void Initialize()
    {
        titleText.text = string.Concat(merchant.merchantName,"의 상점");

        // 상인 판매 물품
        merchantSlot = new Slot[merchantSlotCotainer.childCount];
        for (int i = 0; i < merchantSlotCotainer.childCount; i++)
        {
            ShoppingSlot slot = merchantSlotCotainer.GetChild(i).GetComponent<ShoppingSlot>();
            merchantSlot[i] = slot;
            slot.Initialize(i, merchant, SelectMerchantSlot);
        }
        
        // 캐릭터 인벤토리 표시
        playerSlot = new Slot[playerSlotCotainer.childCount];
        for (int i = 0; i < playerSlotCotainer.childCount; i++)
        {
            ItemSlot slot = playerSlotCotainer.GetChild(i).GetComponent<ItemSlot>();
            playerSlot[i] = slot;
            slot.Initialize(i, SelectPlayerSlot);
        }

        selectedIndex = -1;
        ClearSelectOption();
    }

    void SelectMerchantSlot(int id)
    {
        if (merchant.itemsOnSale.Length <= id) return;

        selectedIndex = id;

        ItemData item = merchant.itemsOnSale[id];
        
        ShowSelectOption(item, true);
    }

    void SelectPlayerSlot(int id)
    {
        selectedIndex = id;

        ItemData item = DataManager.Instance.Inventory.items[id].data;

        ShowSelectOption(item, false);
    }

    void ShowSelectOption(ItemData data, bool isBuy)
    {
        itemNameText.text = data.itemName;
        itemEffectText.text = data.GetItemInfo();
        isBuying = isBuy;

        if(isBuy)
        {
            itemPriceText.text = string.Concat("구매 가격: ", data.price.ToString(), " G");

            buyButton.SetActive(true);
            sellButton.SetActive(false);
        }
        else
        {
            itemPriceText.text = string.Concat("판매 가격: ", data.price.ToString(), " G");

            buyButton.SetActive(false);
            sellButton.SetActive(true);
        }
    }

    void ClearSelectOption()
    {
        itemNameText.text = string.Empty;
        itemEffectText.text = string.Empty;
        itemPriceText.text = string.Empty;
    }

    void UpdateUI()
    {
        for (int i = 0; i < merchantSlot.Length; i++)
        {
            merchantSlot[i].Set();
        }
        
        for (int i = 0; i < playerSlot.Length; i++)
        {
            playerSlot[i].Set();
        }
    }
    
    public void OnClickBuy()
    {
        if(!isBuying) 
            return;
        ItemData item = merchant.itemsOnSale[selectedIndex];
        // 지불
        if (DataManager.Instance.Property.Pay(EProperty.Gold, item.price))
        {
            // 인벤토리에 추가
            DataManager.Instance.Inventory.AddItem(item);
            // 상인은 물건이 사라지지 않음
            UpdateUI();
        }
    }

    public void OnClickSell()
    {
        if(isBuying) 
            return;
        
        ItemData item = DataManager.Instance.Inventory.items[selectedIndex].data;
        
        if(item == null) 
            return;
        
        // 대금
        DataManager.Instance.Property.Earn(EProperty.Gold, item.price);

        // 인벤토리에서 제거
        DataManager.Instance.Inventory.RemoveItem(selectedIndex);
        // 상인은 물건이 추가되지 않음
        UpdateUI();
    }
}
