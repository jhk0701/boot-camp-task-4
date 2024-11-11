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
            stateMachine.ChangeState(stateMachine.SearchState);
            stateMachine.Player.Target = enemy;
        }
        else
        {
            Debug.Log("적이 없음");
            // 스테이지 종료
        }
    }
}