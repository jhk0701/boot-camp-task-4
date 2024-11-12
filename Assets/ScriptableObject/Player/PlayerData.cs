using System;
using UnityEngine;

[Serializable]
public struct StatusData
{
    public EStatus type;
    public float initialValue;
    public float maximumValue;
}


[Serializable]
public struct AbilityData
{
    public EAbility type;
    public float initialValue;
    public float applyingValue; // 힘 n 당 1의 데미지를 얻기 등등으로 사용 예정
}

[CreateAssetMenu(fileName ="New Player Data", menuName = "New Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Search State")]
    public float searchCheckRate = 0.2f;

    [Header("Attack State")]
    public float attackRange = 10f;
    public float attackRate = 1f;

    [Header("Status")]
    public StatusData[] status;

    [Header("Ability")]
    public AbilityData[] ability;
}