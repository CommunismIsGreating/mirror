using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerStates/Grab", fileName = "PlayerState_grab")]
public class PlayerState_grab : PlayerState
{
    [SerializeField]float grabSpeed = 1.0f;
    [SerializeField]float grabMaxTime = 1.0f;
    [SerializeField] float grabMinTime = 0.2f;
    Vector2 grabDir;
    public override void Enter()
    {
        base.Enter();
        Debug.Log("state:grab");
        script.setV(Vector3.zero);
        grabDir = new Vector2(input.AxisX,input.AxisY);
        script.ChangeGrabStartTime();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (input.Jump)
        {
            input.setJumpInputBufferTimer();
        }
        if (stateDuration >= grabMaxTime&&script.IsGround)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_idle)]);
        }
        if (stateDuration >= grabMaxTime)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_coyoTime)]);
        }
        if(script.IsAttach&&stateDuration>grabMinTime)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_attach)]);
        }

    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        script.setV(grabDir*grabSpeed);
    }
}
