using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerStates/Land", fileName = "PlayerState_land")]
public class PlayerState_land : PlayerState
{
    [SerializeField] float stiffTime = 0.2f;
    public override void Enter()
    {
        base.Enter();
        Debug.Log("state:land");
        script.setV(Vector3.zero);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (input.HasJumpInputBuffer||input.Jump)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_jump)]);
        }

        if(stateDuration<stiffTime)
        {
            return;
        }

        if (input.move)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_run)]);
        }
        if (IsAnimFinish)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_idle)]);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
