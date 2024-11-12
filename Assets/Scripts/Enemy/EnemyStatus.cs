using UnityEngine;

public class EnemyStatus : MonoBehaviour, IDamagable
{
    public bool IsDead { get; private set; }
    
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        if(health <= 0f) return;

        health -= amount;
        
        if(health <= 0f)
            IsDead = true;
    }

}