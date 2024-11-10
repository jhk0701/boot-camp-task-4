using TMPro;
using UnityEngine;

public class UIPropertyText : MonoBehaviour
{
    [SerializeField] EProperty target;
    [SerializeField] TextMeshProUGUI text;

    void Start()
    {
        Property property = CharacterManager.Instance.Player.property.properties[target];
        property.onValueChange += UpdateUI;
        UpdateUI(property.Value);
    }

    void UpdateUI(ulong value)
    {
        // TODO : 표기 수정 필요
        text.text = value.ToString(); 
    }
}