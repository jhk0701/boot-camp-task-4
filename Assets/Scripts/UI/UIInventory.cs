using UnityEngine;
using TMPro;

public class UIInventory : UIModal
{
    Inventory inventory;

    [SerializeField] Transform slotContainer;
    [SerializeField] Slot[] slots;

    [Header("Selected")]
    [SerializeField] GameObject selectOption;
    [SerializeField] TextMeshProUGUI selectedItemName;
    [SerializeField] TextMeshProUGUI selectedItemEffects;
    [SerializeField] GameObject useButton;
    [SerializeField] GameObject equipButton;
    int selectedIndex = -1;


    void Awake()
    {
        inventory = DataManager.Instance.Inventory;

        inventory.OnChanged += (index) => 
        {
            slots[index].Set();
            SelectSlot(index);
        };

        slots = new ItemSlot[slotContainer.childCount];
        for (int i = 0; i < slotContainer.childCount; i++)
        {
            slots[i] = slotContainer.GetChild(i).GetComponent<ItemSlot>();
            slots[i].Initialize(i, SelectSlot);

            slots[i].Clear();
        }

        selectOption.SetActive(false);
    }

    public override void Initialize()
    {
        UpdateUI();
    }

    private void OnDisable()
    {
        selectOption.SetActive(false);
    }

    void UpdateUI()
    {
        foreach(ItemSlot slot in slots)
        {
            slot.Set();
        }
    }

    void SelectSlot(int id)
    {
        Item item = inventory.items[id];

        if(item == null || item.data == null)
        {
            selectOption.SetActive(false);
            return;
        }
        
        selectedIndex = id;

        DisplaySelectedItem(item.data);
    }

    void DisplaySelectedItem(ItemData data)
    {
        selectOption.SetActive(true);

        selectedItemName.text = data.itemName;
        selectedItemEffects.text = data.GetItemInfo();
        
        if (data is ConsumableItemData)
        {
            useButton.SetActive(true);
            equipButton.SetActive(false);
        }
        else if(data is EquipableItemData)
        {
            useButton.SetActive(false);
            equipButton.SetActive(true);
        }
    }

    public void OnClickUse()
    {
        Item item = inventory.items[selectedIndex];
        ConsumableItemData data = item.data as ConsumableItemData;

        if (data == null) return;

        foreach (ConsumeEffect effect in data.effects)
            effect.Use();

        inventory.RemoveItem(selectedIndex, 1);
    }

    public void OnClickEquip()
    {
        Item item = inventory.items[selectedIndex];
        if(!item.data is EquipableItemData || item.data == null) return;

        DataManager.Instance.Equipment.Equip(item);
        inventory.RemoveItem(selectedIndex);
        
        UpdateUI();
    }

    public void OnClickDisassemble()
    {
        Item item = inventory.items[selectedIndex];
        if (item.data == null) return;
        
        inventory.DisassembleItem(item.data);
        inventory.RemoveItem(selectedIndex);
    }

    public void OnClickClose()
    {
        UIManager.Instance.CloseModal(this);
    }
}
