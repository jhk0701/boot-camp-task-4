using System;
using System.Collections.Generic;
using UnityEngine;


// TODO : 플레이어 정보 세이브 & 로드 대상
public class PlayerStatus : MonoBehaviour, IDamagable
{
    Player player;
    public Status data => DataManager.Instance.Status;

    public bool IsDead { get => data.status[EStatus.Health].Value <= 0f; }
    
    public event Action OnPlayerDead;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    void Start()
    {
        data.status[EStatus.Health].OnValueChange += (curHp, maxHp)=>
        {
            if (curHp <= 0f)
                OnPlayerDead?.Invoke();
        };
    }

    public void RecoverStatus(EStatus type, float amount)
    {
        data.Add(type, amount);
    }

    public bool UseStatus(EStatus type, float amount)
    {
        if (data.status[type].Value - amount < 0)
            return false;
        
        data.Subtract(type, amount);
        return true;
    }

    public void TakeDamage(float amount)
    {
        // 방어력 적용
        amount = MathF.Max(amount - player.Ability.GetValue(EAbility.Defense), 0f);
        data.status[EStatus.Health].Subtract(amount);
    }

}