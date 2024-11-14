using UnityEngine;

public abstract class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() {}

    public virtual void Exit() {}

    public virtual void FixedUpdate(){}

    public virtual void Update(){}


    protected bool IsInAttackRange()
    {
        Player player = stateMachine.Player;
        float sqrDistance = (player.transform.position - player.Target.transform.position).sqrMagnitude;
        float attackRange = player.data.attackRange;

        return sqrDistance <= attackRange * attackRange;
    }
}