using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StateMachine<T>  {
    public delegate T StateMachineAction();

    private Dictionary<T, StateMachineAction> _actions = new Dictionary<T, StateMachineAction>();

    public T State { get; set; }
    public StateMachineAction this[T state]
    {
        get { return _actions[state];}
        set { _actions[state] = value;}
    }

    public void Update() =>  State = _actions[State]();
	
}
