using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class playerMovement : MonoBehaviour
{
    public float Speed = 15;
    public Rigidbody Rb;

    public float RaycastRange = 1.1f;

    public float jumpForce;

    public float gravityScale = 1.0f;
    public static float globalGravity = 9.81f;
    
    private bool jumpTrue;
    public float Timer;
    private float Countdown; 
   
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
        else if (IsGrounded())
        {
            Rb.velocity = new Vector3(Rb.velocity.x, 0, Rb.velocity.z);
        }
        else if (!IsGrounded())
        {
            Rb.AddForce(gravity * Time.deltaTime, ForceMode.Acceleration);
        }
        
        Rb.AddForce(Vector3.forward * Speed * Time.deltaTime, ForceMode.VelocityChange);
    }
    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, RaycastRange);
    }
}
