using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected IState currentState;
    public Dictionary<System.Type,IState>stateTable;
    private void Update()
    {
        currentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        currentState.PhysicsUpdate();
    }
    protected void SwitchON(IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }
    public void SwitchState(IState newState)
    {
        currentState.Exit();
        SwitchON(newState);
    }
    public void SwitchState(System.Type newState)
    {
        SwitchState(stateTable[newState]);
    }
}
