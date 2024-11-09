public interface IState
{
    void Enter();
    void Exit();

    // 구체적인 행위
    void Update();
}

public class StateMachine
{
    protected IState currentState;

    public void SetState(IState state)
    {
        currentState?.Exit();

        currentState = state;

        currentState?.Enter();
    }

    public void StateUpdate()
    {
        currentState.Update();
    }

}