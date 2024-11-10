using UnityEngine;

[CreateAssetMenu(fileName ="New Stage", menuName = "New Stage")]
public class Stage : ScriptableObject
{
    public int mapId;
    // 적 배치
    // 스테이지 보상

    public string GetInformation()
    {
        return $"Stage Info - {mapId}";
    }
}