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
    
    // TODO : 유저 이름 정보 받아올 것
    string playerName = "Player";

    void Start()
    {    
        PlayerLevel playerLevel = CharacterManager.Instance.Player.Level;
        playerLevel.onLevelChanged += UpdateLevelUI;
        playerLevel.onExperienceChanged += UpdateExperienceUI;

        UpdateLevelUI(playerLevel.Level);
        UpdateExperienceUI(playerLevel.Experience, playerLevel.RequiredExperience);
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