using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : UIModal
{
    public MerchantData merchant;

    // TODO : 상인 품목에 따라 동적 생성하기
    Slot[] merchantSlot;
    Slot[] playerSlot;

    [SerializeField] Transform merchantSlotCotainer;
    [SerializeField] Transform playerSlotCotainer;

    public override void Initialize()
    {
        // 상인 판매 물품
        merchantSlot = new Slot[merchantSlotCotainer.childCount];
        for (int i = 0; i < merchantSlotCotainer.childCount; i++)
        {
            ShoppingSlot slot = merchantSlotCotainer.GetChild(i).GetComponent<ShoppingSlot>();
            slot.Initialize(i, merchant, SelectMerchantSlot);
        }
        
        // 캐릭터 인벤토리 표시
        playerSlot = new Slot[playerSlotCotainer.childCount];
        for (int i = 0; i < playerSlotCotainer.childCount; i++)
        {
            ItemSlot slot = playerSlotCotainer.GetChild(i).GetComponent<ItemSlot>();
            slot.Initialize(i, SelectPlayerSlot);
        }

        // 캐릭터 재산 표시
    }

    void SelectMerchantSlot(int id){}
    void SelectPlayerSlot(int id){}

}
