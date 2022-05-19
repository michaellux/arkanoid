using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class FinishGameState : State
{
    internal FinishGameState()
    {
        UIManager.instance.ShowFinishPanel();
        GameManager.instance.ResetAll();
    }

    protected override void ChangeState(StateMachine stateMachine, PlayerStatuses eventItem)
    {
        switch (eventItem)
        {
            case PlayerStatuses.PlayerInGame:
                stateMachine.State = new StartGameState();
                break;
            default:
                break;
        }
    }
}
