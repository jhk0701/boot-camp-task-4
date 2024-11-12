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
        
        NavMeshAgent agent = stateMachine.Player.Agent;
        agent.isStopped = true;
        agent.speed = 0f;
        agent.SetDestination(stateMachine.Player.transform.position);
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Player.Target.Status.IsDead)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }

        if (Time.time - lastAttackRate > stateMachine.Player.data.attackRate)
        {
            lastAttackRate = Time.time;
            Attack();
        }
    }

    void Attack()
    {
        if (stateMachine.Player.Target.Status.IsDead) 
            return;

        if (IsInAttackRange() && stateMachine.Player.Target.TryGetComponent(out IDamagable damagable))
        {
            // TODO : 코루틴으로 공격 방식 변경
            damagable.TakeDamage(stateMachine.Player.Ability.GetValue(EAbility.Strength));
        }
        else
        {
            stateMachine.ChangeState(stateMachine.SearchState);
        }
    }
}