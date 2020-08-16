﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
	public float movementSpeed;
	public Rigidbody2D rb;

	Vector2 movement;

    void Start()
    {
        
    }

   
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate(){
    	rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}