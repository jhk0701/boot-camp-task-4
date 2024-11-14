using UnityEngine;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine stateMachine;
    
    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    
    public virtual void Enter() {}

    public virtual void Exit() {}

    public virtual void FixedUpdate(){}

    public virtual void Update(){}
    
}