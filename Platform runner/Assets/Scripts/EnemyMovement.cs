﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;

    public float rotationSpeed;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.position - transform.position;
        direction.y = 0;

        transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), 0.9f * Time.deltaTime);
        transform.Translate (0,0, rotationSpeed);
    }
}