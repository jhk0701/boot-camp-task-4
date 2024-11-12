using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerStart : Singleton<UIManagerStart>
{
    public GameObject modal;

    public UIModal inventory;
    public UIModal shop;

    public void OpenModal(UIModal uiModal)
    {
        if (modal.activeInHierarchy)
            return;

        modal.SetActive(true);
        uiModal.Open();
    }

    public void CloseModal(UIModal uiModal)
    {
        modal.SetActive(false);
        uiModal.Close();
    }
}
