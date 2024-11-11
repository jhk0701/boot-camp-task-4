public class PlayerStateMachine : StateMachine
{
    public Player Player { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerSearchState SearchState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }
    
    public PlayerStateMachine(Player player)
    {
        Player = player;

        IdleState = new PlayerIdleState(this);
        SearchState = new PlayerSearchState(this);
        AttackState = new PlayerAttackState(this);

        ChangeState(IdleState);
    }
}