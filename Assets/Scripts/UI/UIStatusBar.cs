using System;
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
        RangedStat stat = CharacterManager.Instance.Player.Status.data.status[target] as RangedStat;
    
        stat.OnValueChange += UpdateUI;
        UpdateUI(stat.Value, stat.GetMax());

        GameManager.Instance.OnGameOver += ReleaseSubscribe;
    }


    void UpdateUI(float current, float max)
    {
        bar.fillAmount = current / max;
        text.text = $"{current} / {max}";
    }

    void ReleaseSubscribe()
    {
        RangedStat stat = CharacterManager.Instance.Player.Status.data.status[target] as RangedStat;
        stat.OnValueChange -= UpdateUI;
    }
}