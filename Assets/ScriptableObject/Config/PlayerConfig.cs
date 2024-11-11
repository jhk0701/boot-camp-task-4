using System;
using UnityEngine;

[Serializable]
public struct StatusConfig
{
    public EStatus type;
    public float initialValue;
    public float maximumValue;
}


[Serializable]
public struct AbilityConfig
{
    public EAbility type;
    public float initialValue;
    public float applyingValue; // 힘 n 당 1의 데미지를 얻기 등등으로 사용 예정
}

[CreateAssetMenu(fileName ="New Player Config", menuName = "New Player Config")]
public class PlayerConfig : ScriptableObject
{
    [Header("Search State")]
    public float searchCheckRate = 0.2f;

    [Header("Attack State")]
    public float attackRange = 10f;
    public float attackRate = 1f;

    [Header("Status")]
    public StatusConfig[] statusConfigs;

    [Header("Ability")]
    public AbilityConfig[] abilityConfigs;
}