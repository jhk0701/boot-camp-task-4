using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData data;
    [field:SerializeField] public bool IsDead {get; set;}

    void Awake()
    {
        CharacterManager.Instance.enemies.Add(this);
    }
}