using UnityEngine;
using UnityEngine.AI;

public class EnemyWanderState : EnemyBaseState
{
    public EnemyWanderState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        Enemy enemy = stateMachine.Enemy;
        enemy.Agent.isStopped = false;
        enemy.Agent.speed = enemy.data.walkSpeed;

        Vector3 position = GetWanderDestination();
        enemy.Agent.SetDestination(position);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Enemy.Agent.remainingDistance < 0.1f)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }
    }

    Vector3 GetWanderDestination()
    {
        Enemy enemy = stateMachine.Enemy;
        Vector3 position = enemy.transform.position + Random.onUnitSphere * Random.Range(enemy.data.minWanderDistance, enemy.data.maxWanderDistance);
        NavMeshHit hit;
        int tryCount = 0;
        do
        {
            tryCount++;
            if (NavMesh.SamplePosition(position, out hit, enemy.data.detectDistance, NavMesh.AllAreas))
            {
                return hit.position;
            }
        }
        while(tryCount < enemy.data.maxTryOfSamplePosition);

        return Vector3.zero;
    }
}