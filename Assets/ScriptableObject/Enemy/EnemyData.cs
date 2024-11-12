using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "New Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float health = 50f;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;

    [Header("Detect")]
    public float detectDistance = 10f;
    public float detectRange = 10f;
    public float checkRate = 0.5f;
    
    [Header("Battle")]
    public float attackRange = 10f;
    public float attackRate = 1f;
    public float damage = 5f;

    [Header("Wander")]
    public float maxWanderWaitTime = 7f;
    public float minWanderWaitTime = 2f;

    public float maxWanderDistance = 5f;
    public float minWanderDistance = 1f;

    public int maxTryOfSamplePosition = 30;

    // TODO : Reward 처치 보상
}