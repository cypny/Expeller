using System;
using UnityEngine;

public class wall : Enemy
{
    private float timer1;
    private float coolDown1 = 0.5f;
    void Start()
    {
        speed = 1;
        atack = 1;
        health = 10;
        rigidbodyUnit = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToTarget();
        if (isTargetMouse)
        {
            MovetoMouse();
            if (timer1 > 0)
            {
                timer1 -= Time.deltaTime;
            }
            if (timer1 <= 0)
            {
                timer1 = coolDown1;
                TakeDamage(GameController.damageClick);
            }
            if (!Input.GetMouseButton(0))
            {
                isTargetMouse = false;
            }
        }
    }
    private void MoveToTarget()
    {
        moveTargetVector = GetOrtVectorInPosition(target.position, rigidbodyUnit.position);
        rigidbodyUnit.velocity = moveTargetVector * speed;
    }
}
