using System;
using System.Collections.Generic;
using UnityEngine;

// TODO : 플레이어 정보 세이브 & 로드 대상
public class PlayerStat : MonoBehaviour, IDamagable
{

    // 로직에서 사용할 정보로 맵핑
    public Dictionary<EStatus, Stat> status = new Dictionary<EStatus, Stat>();
    public Dictionary<EAbility, Stat> ability = new Dictionary<EAbility, Stat>();

    public event Action OnPlayerDead;


    void Awake()
    {
        Initialize();
    }

    void Start()
    {
        status[EStatus.Health].OnValueChange += CheckHealth;
    }

    public void Initialize()
    {
        // TODO : 데이터 받아올 것
        status.Add(EStatus.Health,  new RangedStat(100f, 100f));
        status.Add(EStatus.Stamina, new RangedStat(100f, 100f));
        status.Add(EStatus.Mana,    new RangedStat(100f, 100f));

        ability.Add(EAbility.Strength,  new PassiveStat(10, 0));
        ability.Add(EAbility.Defense,   new PassiveStat(10, 0));
        ability.Add(EAbility.Dexterity, new PassiveStat(5, 0));
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


    void CheckHealth(float curHp, float maxHp)
    {
        if (curHp <= 0f)
            OnPlayerDead?.Invoke();
    }

    public void TakeDamage(float amount)
    {
        status[EStatus.Health].Subtract(amount);
    }

}