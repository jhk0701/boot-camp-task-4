using TMPro;
using UnityEngine;

public class UIPropertyText : MonoBehaviour
{
    [SerializeField] EProperty target;
    [SerializeField] TextMeshProUGUI text;

    void Start()
    {
        PositiveValue property = DataManager.Instance.Property.properties[target];
        property.OnValueChange += UpdateUI;
        UpdateUI(property.Value);
    }

    void UpdateUI(ulong value)
    {
        // TODO : 표기 수정 필요
        text.text = value.ToString(); 
    }
}