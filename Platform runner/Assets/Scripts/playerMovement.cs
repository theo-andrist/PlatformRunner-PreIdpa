using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float Speed = 15;
    public Rigidbody Rb;

    public float RaycastRange = 1f;

    public float jumpForce;

    public float verticalVelocity;
    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.Impulse);
        }
        else if (IsGrounded())
        {
            Rb.useGravity = false;
            Rb.velocity = new Vector3(0, 0, Rb.velocity.z);
        }
        else
        {
            Rb.useGravity = true;
        }

        Rb.AddForce(0, verticalVelocity, Speed * Time.deltaTime, ForceMode.VelocityChange);
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, RaycastRange);
    }
}
