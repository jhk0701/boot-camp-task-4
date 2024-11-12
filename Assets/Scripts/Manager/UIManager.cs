using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : Singleton<UIManager>
{
    public GameObject modal;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    

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
