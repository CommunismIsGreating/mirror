using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerStates/Dodge", fileName = "PlayerState_dodge")]
public class PlayerState_dodge : PlayerState
{
    float timer = 0f;
    [SerializeField] float time = 0.5f;
    [SerializeField] float dodgeSpeed = 10f;
    [SerializeField] float deceration = 10f;
    public override void Enter()
    {
        base.Enter();
        timer = 0f;
        script.setV_x(dodgeSpeed*script.Dir.x);
        currentSpeed = script.moveSpeed;
        Debug.Log("now State:dodge");
    }
    public override void LogicUpdate()
    {
        timer += Time.deltaTime;
        if (timer>=time)
        {
            if (input.move&&script.IsGround) 
            {
                stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_run)]); 
            }
            if(!input.move)
            {
                stateMachine.SwitchState(stateMachine.stateTable[typeof(PlayerState_idle)]);
            }
        }
        currentSpeed=Mathf.MoveTowards(currentSpeed,dodgeSpeed, deceration*Time.deltaTime);
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        script.setV_x(currentSpeed*script.Dir.x);
    }
    public override void Exit()
    {
        base.Exit();
        script.setV_x(0);
    }
}
