internal abstract class State
{
    internal virtual void HandleButton(StateMachine stateMachine, Events eventItem)
    {
        ChangeState(stateMachine, eventItem);
    }

    protected abstract void ChangeState(StateMachine stateMachine, Events eventItem);
}
