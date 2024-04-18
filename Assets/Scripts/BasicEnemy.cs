using System;
using UnityEngine;

public class BasicEnemy : Enemy
{
    private float vectorlength;
    void Start()
    {
        atack = 1;
        health = 10;
        rigidbodyEnemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        moveVector.x = player.position.x - rigidbodyEnemy.position.x;
        moveVector.y = player.position.y - rigidbodyEnemy.position.y;
        vectorlength = (float)Math.Sqrt(moveVector.x * moveVector.x + moveVector.y * moveVector.y);
        moveVector.x = moveVector.x / vectorlength;
        moveVector.y = moveVector.y / vectorlength;
        rigidbodyEnemy.velocity = moveVector * speed;
    }
}
