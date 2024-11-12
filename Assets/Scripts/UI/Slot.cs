using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public abstract class Slot : MonoBehaviour
{
    public int index;
    
    [SerializeField] protected Image icon;
    [SerializeField] protected TextMeshProUGUI quantityText;
    [SerializeField] protected Button selectButton;

    protected event Action<int> onSelect;


    public void Initialize(int id, Action<int> selectedAction)
    {
        index = id;

        if(selectedAction == null)
            selectButton.interactable = false;
        else
        {   
            selectButton.interactable = true;
            onSelect = selectedAction;
        }

        Set();
    }

    public abstract void Set();
    
    public virtual void Clear()
    {
        icon.sprite = null;
        icon.enabled = false;

        quantityText.text = string.Empty;
    }

    public virtual void Select()
    {
        onSelect?.Invoke(index);
    }
}