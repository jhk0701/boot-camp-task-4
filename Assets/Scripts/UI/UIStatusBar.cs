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
        RangedStat stat = CharacterManager.Instance.Player.Stat.status[target] as RangedStat;

        stat.onValueChange += UpdateUI;
        UpdateUI(stat.Value, stat.Max);
    }

    void UpdateUI(float current, float max)
    {
        bar.fillAmount = current / max;
        text.text = $"{current} / {max}";
    }
}