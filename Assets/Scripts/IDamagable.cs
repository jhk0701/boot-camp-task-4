public interface IDamagable
{
    bool IsDead { get; }
    void TakeDamage(float amount);
}