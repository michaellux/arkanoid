using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class StartGameState : State
{
    internal StartGameState()
    {
        GameManager.instance.InitPlayField();
    }

    protected override void ChangeState(StateMachine stateMachine, PlayerStatuses eventItem)
    {
        switch(eventItem)
        {
            case PlayerStatuses.PlayerWin:
                stateMachine.State = new FinishGameState();
                break;
            case PlayerStatuses.PlayerLose:
                stateMachine.State = new FinishGameState();
                break;
        }
    }
}
