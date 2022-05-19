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
        State = new BallInFieldState();
    }

    public void FindOut(Events eventItem)
    {
        State.HandleButton(this, eventItem);
    }
}

