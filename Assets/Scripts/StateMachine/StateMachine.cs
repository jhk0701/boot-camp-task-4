public interface IState
{
    void Enter();
    void Exit();

    // 구체적인 행위
    void Update();
    void FixedUpdate();
}

public class StateMachine
{
    protected IState currentState;

    public void ChangeState(IState state)
    {
        currentState?.Exit();

        currentState = state;

        currentState?.Enter();
    }

    public virtual void StateUpdate()
    {
        currentState.Update();
    }

    public virtual void StateFixedUpdate()
    {
        currentState.FixedUpdate();
    }

}