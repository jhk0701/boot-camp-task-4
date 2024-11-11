using System;
using UnityEngine;

[Serializable]
public class StatusConfig
{
    public EStatus type;
    public float initialValue = 100f;
    public float maximumValue = 100f;
}


[Serializable]
public class AbilityConfig
{
    public EAbility type;
    public float initialValue = 5f;
    public float applyingValue = 1f;
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