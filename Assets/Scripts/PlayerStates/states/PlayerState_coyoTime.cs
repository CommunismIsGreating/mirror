using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerStates/CoyoTime", fileName = "PlayerState_coyoTime")]
public class PlayerState_coyoTime : PlayerState
{
    [SerializeField]float coyoTime=0.1f;
    public override void Enter()
    {
        base.Enter();
        Debug.Log("now State:coyoTime");
        currentSpeed = script.moveSpeed;
        script.setUseGravity(false);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (input.dodge)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_dodge)]);
            return;
        }
        if (input.Jump)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_jump)]);
        }
        if (stateDuration > coyoTime || !input.move) 
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_fall)]);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        script.Move(currentSpeed);
    }
    public override void Exit()
    {
        base.Exit();
        script.setUseGravity(true);
    }
}
