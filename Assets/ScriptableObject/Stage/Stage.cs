using System;
using UnityEngine;
using CustomData;

[Serializable]
public class EnemyGroup
{
    public Enemy[] enemies;
}

[CreateAssetMenu(fileName ="New Stage", menuName = "New Stage")]
public class Stage : ScriptableObject
{
    public string mapName;
    [Header("Map Setting")]
    public GameObject mapComponent;
    public Vector2Int mapSize;
    [Range(1, 10)] public int nodeLevel = 2;
    
    [Header("Enemy")]
    // 적 배치 // 그룹의 갯수로 맵 내 방을 만들어 줄 것
    public EnemyGroup[] enemyGroup;
    
    [Header("Reward")]
    // 스테이지 보상
    public Reward reward;

    public string GetInformation()
    {
        return mapName;
    }
}