using System;
using System.Collections.Generic;
using UnityEngine;

public enum EStatus
{
    Health,
    Stamina,
    Mana,
}

// TODO : 플레이어 정보 세이브 & 로드 대상
public class PlayerStatus : MonoBehaviour, IDamagable
{
    // 로직에서 사용할 정보로 맵핑
    public Dictionary<EStatus, Stat> status = new Dictionary<EStatus, Stat>();

    public bool IsDead { get => status[EStatus.Health].Value <= 0f; }

    public event Action OnPlayerDead;


    void Awake()
    {
        Initialize();
    }

    void Start()
    {
        status[EStatus.Health].OnValueChange += (curHp, maxHp)=>
        {
            if (curHp <= 0f)
                OnPlayerDead?.Invoke();
        };
    }

    public void Initialize()
    {
        // TODO : 데이터 받아올 것
        Player player = GetComponent<Player>();
        foreach (StatusConfig config in player.config.statusConfigs)
        {
            status.Add(config.type, new RangedStat(config.initialValue, config.maximumValue));  
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

    public void TakeDamage(float amount)
    {
        status[EStatus.Health].Subtract(amount);
    }

}