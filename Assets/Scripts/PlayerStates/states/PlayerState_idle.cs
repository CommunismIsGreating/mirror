using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
[CreateAssetMenu(menuName ="Data/StateMachine/PlayerStates/Idle",fileName ="PlayerState_idle")]
public class PlayerState_idle : PlayerState
{
    [SerializeField] float deceration = 10f;
    public override void Enter()
    {
        base.Enter();
        currentSpeed = script.moveSpeed;
        Debug.Log("now State:idle");
    }
    public override void LogicUpdate()
    {
        if (input.dodge)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_dodge)]);
            return;
        }
        if(input.move)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_run)]);
        }
        if (input.Jump)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_jump)]);
        }
        if (!script.IsGround) 
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_fall)]);
        }
        currentSpeed =Mathf.MoveTowards(currentSpeed, 0f,deceration*Time.deltaTime);
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        script.setV_x(currentSpeed*script.Dir.x);
    }
}
