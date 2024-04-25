using System;
using UnityEngine;

public class BasicEnemy : Enemy
{

    private float constant = 10;
    void Start()
    {
        atack = 1;
        health = 10;
        rigidbodyEnemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveBasicEnemy();
        if (isTargetMouse)
        {
            MovetoMouse();
            if (!Input.GetMouseButton(0))
            {
                isTargetMouse = false;
            }
        }
    }
    private void MoveBasicEnemy()
    {
        moveEnemyVector = GetOrtVectorInPosition(player.position, rigidbodyEnemy.position);
        rigidbodyEnemy.velocity=moveEnemyVector * speed;
    }
}
