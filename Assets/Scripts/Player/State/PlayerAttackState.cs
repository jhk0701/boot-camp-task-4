using UnityEngine;
using UnityEngine.AI;

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
        
        NavMeshAgent agent = stateMachine.Player.Controller.Agent;
        agent.isStopped = true;
        agent.speed = 0f;

        agent.SetDestination(stateMachine.Player.transform.position);
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Player.Target.IsDead)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }

        if (Time.time - lastAttackRate > stateMachine.Player.config.attackRate)
        {
            lastAttackRate = Time.time;
            Attack();
        }
    }

    void Attack()
    {
        if (stateMachine.Player.Target.IsDead) return;

        if (IsInAttackRange() && stateMachine.Player.Target.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(stateMachine.Player.Stat.ability[EAbility.Strength].Value);
        }
        else
        {
            stateMachine.ChangeState(stateMachine.SearchState);
        }
    }
}