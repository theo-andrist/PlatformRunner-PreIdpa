using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] followPoints;

    public float rotationSpeed;

    private Vector3 direction;

    private int randomPosition = 0;
    // Start is called before the first frame update
    void Start()
    {
        randomPosition = Random.Range(0, followPoints.Length);
    }

    // Update is called once per frame
    void Update()
    {
        direction = followPoints[randomPosition].position - transform.position;
        direction.y = 0;

        transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), 0.9f * Time.deltaTime);
        transform.Translate (0,0, rotationSpeed);

        Random.Range(0, followPoints.Length);

    }
}
