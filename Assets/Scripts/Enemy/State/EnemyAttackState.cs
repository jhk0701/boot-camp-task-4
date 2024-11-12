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

        if (IsInAttackRange(out bool isInDetectRange))
        {
            Attack();
        }
        else
        {
            if (isInDetectRange)
            {
                FollowTarget();
            }
            else
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }
    }

    bool IsInAttackRange(out bool isInDetectRange)
    {
        Enemy enemy = stateMachine.Enemy;
        float detectRange = enemy.data.detectRange;
        float attackRange = enemy.data.attackRange;

        float sqrDistance = (enemy.transform.position - enemy.Target.position).sqrMagnitude;
        
        isInDetectRange = sqrDistance <= detectRange * detectRange;
        
        return sqrDistance <= attackRange * attackRange;
    }

    void Attack()
    {
        Enemy enemy = stateMachine.Enemy;
        if (Time.time - lastAttackTime > enemy.data.attackRate)
        {
            lastAttackTime = Time.time;

            if(enemy.Target.TryGetComponent(out IDamagable damagable))
            {
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