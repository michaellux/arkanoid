using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StateMachine
{
    internal State State { get; set; }

    public StateMachine()
    {
        State = new StartGameState();
    }

    public void FindOut(PlayerStatuses eventItem)
    {
        State.HandleButton(this, eventItem);
    }
}

