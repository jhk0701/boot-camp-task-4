using TMPro;
using UnityEngine;

public class UIStageInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    void Start()
    {
        text.text = GameManager.Instance.CurrentStage.GetInformation();
    }
    
}