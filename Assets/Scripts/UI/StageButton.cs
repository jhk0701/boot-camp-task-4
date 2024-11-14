using TMPro;
using UnityEngine;
using System;

public class StageButton : MonoBehaviour
{
    public int index;
    
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI descriptionText;
    
    event Action<int> OnSelect;
    
    public void Initialize(int id, Action<int> OnSelected)
    {
        index = id;
        OnSelect = OnSelected;
        
        Stage data = StageManager.Instance.stages[index];
        nameText.text = data.name;
        // descriptionText.text = data.GetInformation();
    }
    
    public void Select()
    {
        OnSelect?.Invoke(index);
    }

}
