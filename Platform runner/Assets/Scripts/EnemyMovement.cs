using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public jumpCheckRaycast jcr;
    public Rigidbody Rb;
    public bool yellow;
    public bool blue;
    public bool red;
    public float gravityScale = 1.0f;
    public float RaycastRange = 1.1f;

    public float jumpForce;
    private int randomPosition = 0;
    public Transform[] followPoints;
    public GameObject[] positionCheckBoxes;
    public CheckEnemyPosition[] cep;
    public float rotationSpeed;
    private Vector3 direction;
    public float Timer = 1;
    private float Countdown;

    
    // Start is called before the first frame update
    void Start()
    {
        cep = new CheckEnemyPosition[positionCheckBoxes.Length];

        randomPosition = Random.Range(0, followPoints.Length);

        for (int i = 0; i < positionCheckBoxes.Length; i++)
        {
            cep[i] = positionCheckBoxes[i].GetComponent<CheckEnemyPosition>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = followPoints[randomPosition].position - transform.position;
        direction.y = 0;
        if (direction != Vector3.zero) {
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), 0.9f * Time.deltaTime);
        }
            transform.Translate (0,0, rotationSpeed);
        
        if (Countdown > 0) {
            Countdown -= Time.deltaTime;
        }
        if (Countdown <= 0){
            randomPosition = Random.Range(0, followPoints.Length - 1);
            Countdown = Timer;
        }
        if( red && cep[randomPosition].red )  {
            while(cep[randomPosition].red){
            randomPosition = Random.Range(0, followPoints.Length - 1);
            }
        }
        if( yellow && cep[randomPosition].yellow )  {
            while(cep[randomPosition].yellow){
            randomPosition = Random.Range(0, followPoints.Length - 1);
            }
        }
        if( blue && cep[randomPosition].blue )  {
            while(cep[randomPosition].blue){
            randomPosition = Random.Range(0, followPoints.Length - 1);
            }
        }

        Vector3 gravity = playerMovement.globalGravity * gravityScale * Vector3.down;

        if (IsGrounded() && jcr.NeedsToJump())
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
    }
    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, RaycastRange);
    }
}
