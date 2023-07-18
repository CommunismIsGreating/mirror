using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerState : ScriptableObject, IState
{
    [SerializeField] string stateName;
    [SerializeField,Range(0,1)] float transitionDuration=0.1f;
    int stateHash;
    float statestartTime;

    protected Animator animator;
    protected PlayerStateMachine stateMachine;
    protected PlayerInput input;
    protected PlayerScript script;

    protected float stateDuration => Time.time - statestartTime;
    protected bool IsAnimFinish => stateDuration>=animator.GetCurrentAnimatorClipInfo(0).Length;

    protected float currentSpeed;
    public void Initialize(Animator animator,PlayerStateMachine stateMachine,PlayerInput input,PlayerScript script)
    {
        this.animator = animator;
        this.stateMachine = stateMachine;
        this.input = input;
        this.script = script;
    }
    private void OnEnable()
    {
        stateHash=Animator.StringToHash(stateName);
    }
    public virtual void Enter()
    {
        animator.CrossFade(stateHash, transitionDuration);
        statestartTime = Time.time;
    }

    public virtual void Exit()
    {
       
    }

    public virtual void LogicUpdate()
    {
       
    }

    public virtual void PhysicsUpdate()
    {
       
    }
}
