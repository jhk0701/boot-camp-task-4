using UnityEngine;
using UnityEngine.AI;

public class PlayerSearchState : PlayerBaseState
{
    float lastCheckTime = 0;

    public PlayerSearchState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player player = stateMachine.Player;

        NavMeshAgent agent = player.Controller.Agent;
        agent.isStopped = false;
        agent.speed = player.config.baseSpeed;
    }

    public override void Update()
    {
        base.Update();
        if (Time.time - lastCheckTime > stateMachine.Player.config.searchCheckRate)
        {
            lastCheckTime = Time.time;

            if (IsInAttackRange()) // 공격 개시
            {
                stateMachine.ChangeState(stateMachine.AttackState);
            }
            else
            {
                // 정보 갱신
                if (stateMachine.Player.Target.IsDead)
                {
                    stateMachine.ChangeState(stateMachine.IdleState);
                }
                else
                {
                    stateMachine.Player.Controller.Agent.SetDestination(stateMachine.Player.Target.transform.position);
                }
            }

        }
        
    }
}