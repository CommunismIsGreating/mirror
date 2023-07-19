using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody body;
    PlayerInput inputs;
    PlayerGroundDect dect;
    AttachDect attachDect;
    [SerializeField] float grabLength = 10f;
    [SerializeField] LayerMask grabDectLayer;
    //·½Ïò
    public Vector2 Dir=>new Vector2(transform.localScale.x,inputs.AxisY);
    public float moveSpeed => Mathf.Abs( body.velocity.x);
    public bool IsGround => dect.isGround;
    public bool IsFalling => body.velocity.y < 0&&!IsGround;
    public bool IsAttach=>attachDect.isAttach;
    Ray ray =>new Ray(transform.position, Dir);
    public RaycastHit hit;
    [SerializeField] float grabTime = 3f;
    float grabStartTime = 0f;
    float grabTimer=0f;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        inputs = GetComponent<PlayerInput>();
        dect=GetComponentInChildren<PlayerGroundDect>();
        attachDect = GetComponentInChildren<AttachDect>();
    }
    void OnEnable()
    {
       
    }
    void OnDisable()
    {
       
    }

    private void Start()
    {
        inputs.EnableTestmapInput();
    }

    // Update is called once per frame
    void Update()
    {
        grabTimer=(Time.time-grabStartTime);
    }
    public void setV(Vector3 dir)
    {
        body.velocity = dir;
    }
    public void setV_x(float x)
    {
        body.velocity = new Vector3(x,body.velocity.y);
    }
    public void setV_y(float y)
    {
        body.velocity = new Vector3( body.velocity.x,y);
    }
    public void setV_yForce(float force)
    {
        body.AddForce(new Vector3(0, force));
    }
    public void Move(float x)
    {
        if (inputs.move)
        {
            transform.localScale = new Vector3(inputs.AxisX, 1, 1);
        }
        setV_x(x*inputs.AxisX);
    }
    public void setUseGravity(bool value)
    {
        body.useGravity=value;
    }

    //public bool DectGrabIsSuccess()
    //{
    //    Debug.DrawLine(transform.position, hit.point, Color.yellow);
    //    if (Physics.Raycast(ray, out hit,grabLength,grabDectLayer))
    //    {
    //        return true;
    //    }
    //    return false;
    //}
    public float DectLength(Vector3 point)
    {
        return (transform.position - point).magnitude;
    }
    public void ChangeGrabStartTime()
    {
        grabStartTime = Time.time;
    }
    public bool GrabTimerGetTarget()
    {
        return grabTimer > grabTime;
    }
}
