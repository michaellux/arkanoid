internal abstract class State
{
    internal virtual void HandleButton(StateMachine stateMachine, PlayerStatuses eventItem)
    {
        ChangeState(stateMachine, eventItem);
    }

    protected abstract void ChangeState(StateMachine stateMachine, PlayerStatuses eventItem);
}
