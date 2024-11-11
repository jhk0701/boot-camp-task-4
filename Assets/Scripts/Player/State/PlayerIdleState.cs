using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Player.Controller.Agent.isStopped = true;
        stateMachine.Player.Controller.Agent.speed = 0f;

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