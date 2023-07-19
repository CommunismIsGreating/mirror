using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerStates/Fall", fileName = "PlayerState_fall")]
public class PlayerState_fall : PlayerState
{
    [SerializeField] AnimationCurve speedCurve;
    [SerializeField] float jumpMoveSpeed = 5f;
    public override void Enter()
    {
        base.Enter();
        Debug.Log("state:fall");
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (script.IsGround)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_land)]);
        }
        if (input.Jump)
        {
            input.setJumpInputBufferTimer();
        }
        if (input.grab&&script.GrabTimerGetTarget())
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_grab)]);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        script.setV_y( speedCurve.Evaluate(stateDuration));
        script.Move(jumpMoveSpeed);
    }
}
