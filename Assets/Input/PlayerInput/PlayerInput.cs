using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
//Manager player's inputs
public class PlayerInput : MonoBehaviour
{
    Player player;
    Vector2 Axis => player.testmap.Move.ReadValue<Vector2>();
    public bool Jump => player.testmap.Jump.WasPressedThisFrame();
    public float AxisX => (float)Math.Round(Axis.x, MidpointRounding.AwayFromZero);
    public float AxisY => (float)Math.Round(Axis.y, MidpointRounding.AwayFromZero);
    public bool move => AxisX != 0;
    public bool dodge => player.testmap.Dodge.WasPerformedThisFrame();
    public bool grab => player.testmap.Grab.WasPerformedThisFrame();
    public bool isAttach => player.testmap.Attach.WasPressedThisFrame();

    //¥¶¿Ì ‰»Îª∫≥Â
    public bool HasJumpInputBuffer { get; set; }
    [SerializeField] float jumpInputBuffer = 0.5f;
    WaitForSeconds waitJumpInputBuffer;
    private void Awake()
    {
        player = new Player();
        waitJumpInputBuffer = new WaitForSeconds(jumpInputBuffer);
    }
    private void OnEnable()
    {
        player.testmap.Jump.canceled += delegate
        {
            HasJumpInputBuffer = false;
        };
    }
    void Disable()
    {
        DisableAllInputs();
    }
    public void DisableAllInputs()
    {
        player.testmap.Disable();
    }
    public void EnableTestmapInput()
    {
        player.testmap.Enable();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void setJumpInputBufferTimer()
    {
        StopCoroutine(JumpInputBufferCoroutine());
        StartCoroutine(JumpInputBufferCoroutine());
    }

    IEnumerator JumpInputBufferCoroutine()
    {
        HasJumpInputBuffer = true;
        yield return waitJumpInputBuffer;
        HasJumpInputBuffer = false;
    }

}
