using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class playerMovement : MonoBehaviour
{
    public float Speed = 15;
    public Rigidbody Rb;

    public float RaycastRange = 1f;

    public float jumpForce;

    

    public float gravityScale = 1.0f;
    public static float globalGravity = 19.81f;
    
    public bool jumpTrue;
    public float Timer;
    private float Countdown; 

    void Start() {
        //Countdown = Timer;

    }
   
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space) && Countdown <= 0) {
            jumpTrue = true;
            Countdown = Timer;
        }
        if (Countdown > 0) {
            Countdown -= Time.deltaTime;
        }
        else {
            jumpTrue = false;
            
        }
    }
    void FixedUpdate()
    {
         Vector3 gravity = globalGravity * gravityScale * Vector3.down;
         

        if (IsGrounded() && jumpTrue == true)
        {
            Rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.Impulse);
        }
        /* 
        else if (IsGrounded())
        {
            Rb.useGravity = false;
            Rb.velocity = new Vector3(0, 0, Rb.velocity.z);
        }
        else
        {
            Rb.useGravity = true;
        }*/

        //Rb.AddForce(0, verticalVelocity, Speed * Time.deltaTime, ForceMode.VelocityChange);
        Rb.AddForce(gravity, ForceMode.Acceleration);
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, RaycastRange);
    }
}
