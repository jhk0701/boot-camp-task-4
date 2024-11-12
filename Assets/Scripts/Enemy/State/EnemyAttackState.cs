using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    float lastCheckTime = 0;
    float lastAttackTime = 0;
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        Enemy enemy = stateMachine.Enemy;
        enemy.Agent.isStopped = false;
        enemy.Agent.speed = enemy.data.runSpeed;

        enemy.Agent.SetDestination(enemy.Target.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Time.time - lastCheckTime < stateMachine.Enemy.data.checkRate)
            return;

        lastCheckTime = Time.time;

        if (IsInAttackRange(out bool isInFollowRange))
        {
            Attack();
        }
        else
        {
            if (isInFollowRange)
            {
                FollowTarget();
            }
            else
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }
    }

    bool IsInAttackRange(out bool isInFollowRange)
    {
        Enemy enemy = stateMachine.Enemy;
        float followRange = enemy.data.followRange;
        float attackRange = enemy.data.attackRange;

        float sqrDistance = (enemy.transform.position - enemy.Target.position).sqrMagnitude;
        
        isInFollowRange = sqrDistance <= followRange * followRange;
        
        return sqrDistance <= attackRange * attackRange;
    }

    void Attack()
    {
        Enemy enemy = stateMachine.Enemy;
        if (Time.time - lastAttackTime > enemy.data.attackRate)
        {    
            lastAttackTime = Time.time;

            enemy.Agent.isStopped = true;
            enemy.Agent.speed = 0;

            if(enemy.Target.TryGetComponent(out IDamagable damagable))
            {
                if (damagable.IsDead)
                {
                    stateMachine.ChangeState(stateMachine.IdleState);
                    return;
                }

                damagable.TakeDamage(enemy.data.damage);
            }   
        }
    }

    void FollowTarget()
    {
        Enemy enemy = stateMachine.Enemy;
        enemy.Agent.isStopped = false;
        enemy.Agent.speed = enemy.data.runSpeed;

        enemy.Agent.SetDestination(enemy.Target.position);
    }
}