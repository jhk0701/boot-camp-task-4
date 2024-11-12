public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; private set; }

    public EnemyIdleState IdleState { get; private set; }
    public EnemyWanderState WanderState { get; private set; }
    public EnemyAttackState AttackState { get; private set; }

    public EnemyStateMachine(Enemy enemy)
    {
        Enemy = enemy;
        Enemy.OnTargetDetected += ()=>{ ChangeState(AttackState); };

        IdleState = new EnemyIdleState(this);
        WanderState = new EnemyWanderState(this);
        AttackState = new EnemyAttackState(this);

        ChangeState(IdleState);
    }
}