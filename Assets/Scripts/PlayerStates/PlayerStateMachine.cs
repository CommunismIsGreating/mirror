using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    Animator animator;
    PlayerInput input;
    [SerializeField] PlayerState[] states; 
    PlayerScript script;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        stateTable = new Dictionary<Type, IState>();
        input = GetComponentInChildren<PlayerInput>();
        script = GetComponentInChildren<PlayerScript>();
        //initial player's states
        foreach(PlayerState state in states)
        {
            state.Initialize(animator, this,input,script);
            stateTable.Add(state.GetType(), state);
        }
    }
    private void Start()
    {
        SwitchON(stateTable[typeof(PlayerState_idle)]);
    }
}
