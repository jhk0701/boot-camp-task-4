using System.Collections.Generic;
using UnityEngine;

// TODO : 플레이어 정보 세이브 & 로드 대상
public class PlayerStat : MonoBehaviour
{
    // TODO : 스크립터블로 전환하기
    [Header("Player Stat")]
    [SerializeField] RangedStat[] statusStats;
    [SerializeField] PassiveStat[] abilityStats;

    // 로직에서 사용할 정보로 맵핑
    public Dictionary<EStatus, RangedStat> status = new Dictionary<EStatus, RangedStat>();
    public Dictionary<EAbility, PassiveStat> ability = new Dictionary<EAbility, PassiveStat>();


    void Awake()
    {
        for (int i = 0; i < statusStats.Length; i++)
        {
            status.Add(statusStats[i].type, statusStats[i]);
        }

        for (int i = 0; i < abilityStats.Length; i++)
        {
            ability.Add(abilityStats[i].type, abilityStats[i]);
        }
    }


    public void RecoverStatus(EStatus type, float amount)
    {
        status[type].Add(amount);
    }

    public bool UseStatus(EStatus type, float amount)
    {
        if (status[type].Value - amount < 0)
            return false;
        
        status[type].Subtract(amount);
        return true;
    }

    public void AddAbility(EAbility type, float amount)
    {
        ability[type].Add(amount);
    }

    public void SubtractAbility(EAbility type, float amount)
    {
        ability[type].Subtract(amount);
    }
}