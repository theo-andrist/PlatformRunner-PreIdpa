using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class playerMovement : MonoBehaviour
{
    public GameManager gm;

    public float Speed = 25;
    public Rigidbody Rb;

    public float RaycastRange = 1.1f;

    public float jumpForce = 660.0f;

    public float gravityScale = 200.0f;
    public static float globalGravity = 9.81f;
    
    private bool jumpTrue;
    public float Timer = 0.2f;
    private float Countdown; 
   
   private bool wasInAir = false;
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

            if(wasInAir){
                FindObjectOfType<audioManager>().Play("jump-landing");
                wasInAir = false;
            }
        }
        if(!IsGrounded()){

            wasInAir = true;
            Rb.AddForce(gravity * Time.deltaTime, ForceMode.Acceleration);
        }
        /*if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(IsGrounded());
        }*/
        
        Rb.AddForce(transform.forward * Speed * Time.deltaTime, ForceMode.VelocityChange);
        
    }
    public bool IsGrounded()
    {
        bool _isGrounded = false;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, RaycastRange) && hit.transform.tag == "Cube")
        {
            _isGrounded = true;
        }
        return _isGrounded;
    }
}
