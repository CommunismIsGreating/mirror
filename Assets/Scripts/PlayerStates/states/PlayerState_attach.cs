using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerStates/Attach", fileName = "PlayerState_attach")]
public class PlayerState_attach : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("state:attach");
        script.setV(Vector3.zero);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!script.IsAttach)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_coyoTime)]);
        }
        if (input.Jump||input.HasJumpInputBuffer)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_jump)]);
        }
        if (input.isAttach)
        {
            stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_fall)]);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
       script.setV(Vector3.zero);
    }
}
