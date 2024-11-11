using UnityEngine;

[CreateAssetMenu(fileName ="New Enemy Config", menuName ="New Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    public float detectRate = 1f;
    public float detectDistance = 10f;

    [Header("Wander")]
    public float maxWanderWaitTime = 7f;
    public float minWanderWaitTime = 2f;

    public float maxWanderDistance = 5f;
    public float minWanderDistance = 1f;

    public int maxTryOfSamplePosition = 30;

}