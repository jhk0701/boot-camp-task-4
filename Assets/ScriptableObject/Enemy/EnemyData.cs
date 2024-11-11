using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "New Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float health = 50f;
    public float damage = 5f;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;

    // TODO : Reward 처치 보상
}