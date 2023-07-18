using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody body;
    PlayerInput inputs;
    PlayerGroundDect dect;
    //·½Ïò
    public Vector2 Dir=>new Vector2(transform.localScale.x,0);
    public float moveSpeed => Mathf.Abs( body.velocity.x);
    public bool IsGround => dect.isGround;
    public bool IsFalling => body.velocity.y < 0&&!IsGround;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        inputs = GetComponent<PlayerInput>();
        dect=GetComponentInChildren<PlayerGroundDect>();
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
}
