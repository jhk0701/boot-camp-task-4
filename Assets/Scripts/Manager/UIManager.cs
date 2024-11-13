using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject commonCanvas;
    [SerializeField] GameObject modalCanvas;

    public UILoading UILoading { get; set; }
    

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    

    public void OpenModal(UIModal uiModal)
    {
        if (modalCanvas.activeInHierarchy)
            return;

        modalCanvas.SetActive(true);
        uiModal.Open();
    }

    public void CloseModal(UIModal uiModal)
    {
        modalCanvas.SetActive(false);
        uiModal.Close();
    }
}
