using UnityEngine;

[CreateAssetMenu(fileName ="New Player Config", menuName ="New Player Config")]
public class PlayerConfig: ScriptableObject
{
    public float baseSpeed = 10f;

    [Header("Search")]
    public float searchCheckRate = 0.2f;

    [Header("Attack")]
    public float attackRange = 10f;
    public float attackRate = 1f;
}