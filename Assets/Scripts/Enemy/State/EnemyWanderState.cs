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

        Vector3 position = GetNewDestination();
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

    Vector3 GetNewDestination()
    {
        EnemyConfig config = CharacterManager.Instance.enemyConfig;
        Vector3 position = stateMachine.Enemy.transform.position + Random.onUnitSphere * Random.Range(config.minWanderDistance, config.maxWanderDistance);
        NavMeshHit hit;
        int tryCount = 0;
        do
        {
            tryCount++;
            if (NavMesh.SamplePosition(position, out hit, config.detectDistance, NavMesh.AllAreas))
            {
                return hit.position;
            }
        }
        while(tryCount < config.maxTryOfSamplePosition);

        return Vector3.zero;
    }
}