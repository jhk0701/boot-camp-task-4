using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour, IDamagable
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        if(health <= 0f) return;

        health -= amount;
        
        if(health <= 0f)
            GetComponent<Enemy>().IsDead = true;
    }

}