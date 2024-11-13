using System;
using UnityEngine;
using CustomData;



[CreateAssetMenu(fileName ="New Stage", menuName = "New Stage")]
public class Stage : ScriptableObject
{
    public string mapName;
    
    // 적 배치 // 그룹의 갯수로 맵 내 방을 만들어 줄 것
    public EnemyGroup[] enemyGroup;
    
    // 스테이지 보상
    public Reward reward;

    public string GetInformation()
    {
        return mapName;
    }
    
    [Serializable]
    public class EnemyGroup
    {
        public Enemy[] enemies;
    }
}