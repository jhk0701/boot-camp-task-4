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

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (Time.time - lastCheckTime > stateMachine.Player.config.searchCheckRate)
        {
            lastCheckTime = Time.time;
            

            if (IsInAttackRange())
            {
                stateMachine.ChangeState(stateMachine.AttackState);
            }
            else
            {
                // 갱신
                if(stateMachine.Player.Target.IsDead)
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

    bool IsInAttackRange()
    {
        Player player = stateMachine.Player;
        float sqrDistance = (player.transform.position - player.Target.transform.position).sqrMagnitude;
        float attackRange = player.config.attackRange;
        
        return sqrDistance <= attackRange * attackRange;
    }

    
}