using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlayerInfo : MonoBehaviour
{
    // 더 세분화하기엔 번거로움이 있어보여서 이름까지는 포함
    // 이름 : 텍스트
    // 레벨 : 텍스트
    // 경험치 : 바 + 텍스트
    [SerializeField] TextMeshProUGUI playerInfoText; // Lv. n 플레이어 이름
    [SerializeField] TextMeshProUGUI experienceText;
    [SerializeField] Image experienceBar;
    
    string playerName = "Player";

    void Start()
    {
        playerName = DataManager.Instance.PlayerData.playerName;
        Level playerLevel = DataManager.Instance.Level;
        playerLevel.OnLevelChanged += UpdateLevelUI;
        playerLevel.OnExperienceChanged += UpdateExperienceUI;

        UpdateLevelUI(playerLevel.LevelValue);
        UpdateExperienceUI(playerLevel.Experience, playerLevel.RequiredExperience);
    }

    private void OnDisable()
    {
        Level playerLevel = DataManager.Instance.Level;
        playerLevel.OnLevelChanged -= UpdateLevelUI;
        playerLevel.OnExperienceChanged -= UpdateExperienceUI;
    }

    void UpdateLevelUI(int level)
    {
        playerInfoText.text = $"Lv.{level} {playerName}";
    }

    void UpdateExperienceUI(float current, float required)
    {
        experienceBar.fillAmount = current / required;
        experienceText.text = $"{current} / {required}";
    }
}