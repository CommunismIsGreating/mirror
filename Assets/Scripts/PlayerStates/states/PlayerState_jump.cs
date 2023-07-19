using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerStates/Jump", fileName = "PlayerState_jump")]
public class PlayerState_jump : PlayerState
{
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float addForce=1f;
    [SerializeField] float addForceTime=1f;
    [SerializeField] float jumpMoveSpeed = 5f;
    bool isjump = true;

    public override void Enter()
    {
        base.Enter();
        Debug.Log("now State:jump");
        script.setV_y(jumpForce);
        isjump = true;
        input.HasJumpInputBuffer = false;
    }
    public override void LogicUpdate()
    {
        if (script.IsFalling)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_fall)]);
        }
        if (input.grab && script.GrabTimerGetTarget())
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_grab)]);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (Keyboard.current.spaceKey.isPressed&&stateDuration<=addForceTime&&isjump)
        {
            script.setV_yForce(jumpForce);
        }else if(Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            isjump = false;
        }

        script.Move(jumpMoveSpeed);
    }
}
