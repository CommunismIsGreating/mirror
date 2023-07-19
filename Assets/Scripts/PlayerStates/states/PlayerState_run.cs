using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerStates/Run", fileName = "PlayerState_run")]
public class PlayerState_run : PlayerState
{
    [SerializeField]public float moveSpeed = 1f;
    [SerializeField]float acceration = 10f;
    public override void Enter()
    {
        base.Enter();
        Debug.Log("now State:run");
        currentSpeed = script.moveSpeed;
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (input.dodge)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_dodge)]);
            return;
        }
        if (!input.move)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_idle)]);
        }
        if (input.Jump&&script.IsGround)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_jump)]);
        }
        if (!script.IsGround)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_coyoTime)]);
        }
        if (input.grab && script.GrabTimerGetTarget())
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_grab)]);
        }
        currentSpeed =Mathf.MoveTowards(currentSpeed, moveSpeed,acceration*Time.deltaTime );
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        script.Move(moveSpeed);
    }
    public override void Exit()
    {
        base.Exit();
    }
}
