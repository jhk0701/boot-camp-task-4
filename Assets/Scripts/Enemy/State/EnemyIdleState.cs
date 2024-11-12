using System.Collections;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    WaitForSeconds waitForSec;
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
        waitForSec = new WaitForSeconds(1f);
    }

    public override void Enter()
    {
        base.Enter();

        Enemy enemy = stateMachine.Enemy;
        enemy.Agent.isStopped = true;
        enemy.Agent.speed = 0f;
        enemy.Agent.SetDestination(enemy.transform.position);

        Wait();
    }

    public override void Exit()
    {
        base.Exit();

        // 대기 도중에 적 발견될 수 있으므로 확인
        if(IdleHandler != null)
        {
            stateMachine.Enemy.StopCoroutine(IdleHandler);
            IdleHandler = null;
        }
    }

    void Wait()
    {
        Enemy enemy = stateMachine.Enemy;
        float waitTime = Random.Range(enemy.data.minWanderWaitTime, enemy.data.maxWanderWaitTime);

        if(IdleHandler != null)
        {
            enemy.StopCoroutine(IdleHandler);
            IdleHandler = null;
        }

        IdleHandler = enemy.StartCoroutine(Idle(waitTime));
    }

    Coroutine IdleHandler;
    IEnumerator Idle(float waitTime)
    {
        float elapsedTime = 0f;
        while(elapsedTime < waitTime)
        {
            yield return waitForSec;
            elapsedTime++;
        }

        stateMachine.ChangeState(stateMachine.WanderState);
        IdleHandler = null;
    }

}