using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour, IDamagable
{
    [field:SerializeField] public bool IsDead { get; set; }
    
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        if(health <= 0f) return;

        health -= amount;
        
        if(health <= 0f)
            IsDead = true;
    }

}