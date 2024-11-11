using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStatusBar : MonoBehaviour
{
    [SerializeField] EStatus target;
    [SerializeField] Image bar;
    [SerializeField] TextMeshProUGUI text;
    
    void Start()
    {
        RangedStat stat = CharacterManager.Instance.Player.Status.status[target] as RangedStat;
    
        Debug.Log(stat == null);

        stat.OnValueChange += UpdateUI;
        UpdateUI(stat.Value, stat.Max);
    }

    void UpdateUI(float current, float max)
    {
        bar.fillAmount = current / max;
        text.text = $"{current} / {max}";
    }
}