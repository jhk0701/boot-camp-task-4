using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public abstract class Slot : MonoBehaviour
{
    public int index;
    
    [SerializeField] protected Image icon;
    [SerializeField] protected Sprite defaultIcon;
    [SerializeField] protected TextMeshProUGUI quantityText;
    [SerializeField] protected Button selectButton;

    protected event Action<int> OnSelect;

    public virtual void Initialize(int id, Action<int> selectedAction)
    {
        index = id;

        if(selectedAction == null)
            selectButton.interactable = false;
        else
        {   
            selectButton.interactable = true;
            OnSelect = selectedAction;
        }

        Set();
    }

    public abstract void Set();
    
    public virtual void Clear()
    {
        icon.sprite = defaultIcon;
        quantityText.text = string.Empty;
    }

    public virtual void Select()
    {
        OnSelect?.Invoke(index);
    }
}