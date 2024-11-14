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

        NavMeshAgent agent = player.Agent;
        agent.isStopped = false;
        agent.speed = player.Ability.GetValue(EAbility.Dexterity); // 민첩에서 속도 얻기
    }

    public override void Update()
    {
        base.Update();
        if (Time.time - lastCheckTime > stateMachine.Player.data.searchCheckRate)
        {
            lastCheckTime = Time.time;

            if (IsInAttackRange()) // 공격 개시
            {
                stateMachine.ChangeState(stateMachine.AttackState);
            }
            else
            {
                // 정보 갱신
                if (stateMachine.Player.Target.Status.IsDead)
                {
                    stateMachine.ChangeState(stateMachine.IdleState);
                }
                else
                {
                    stateMachine.Player.Agent.SetDestination(stateMachine.Player.Target.transform.position);
                }
            }

        }
        
    }
}