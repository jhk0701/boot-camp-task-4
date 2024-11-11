using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    float lastAttackRate = 0f;
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        lastAttackRate = 0f;
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Player.Target.IsDead)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }

        if(Time.time - lastAttackRate > stateMachine.Player.config.attackRate)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (stateMachine.Player.Target.IsDead) return;

        if(stateMachine.Player.Target.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(stateMachine.Player.Stat.ability[EAbility.Strength].Value);
        }
    }
}