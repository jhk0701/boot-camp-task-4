using System;
using UnityEngine;


[CreateAssetMenu(fileName ="New Character Data", menuName = "New Character Data")]
public class CharacterData : ScriptableObject
{
    [Header("Search State")]
    public float searchCheckRate = 0.2f;

    [Header("Attack State")]
    public float attackRange = 10f;
    public float attackRate = 1f;

}