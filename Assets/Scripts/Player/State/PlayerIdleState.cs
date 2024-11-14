using UnityEngine;
using UnityEngine.AI;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        NavMeshAgent agent = stateMachine.Player.Agent;

        agent.SetDestination(stateMachine.Player.transform.position);
        agent.isStopped = true;
        agent.speed = 0f;

        // 목표물 찾기
        Enemy enemy = CharacterManager.Instance.GetNearestEnemy();
        if(enemy != null)
        {
            stateMachine.Player.Target = enemy;
            stateMachine.ChangeState(stateMachine.SearchState);
        }
        else
        {
            // 스테이지 종료
            GameManager.Instance.StageEnd(true);
        }
    }
}