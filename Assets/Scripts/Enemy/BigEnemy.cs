using UnityEngine;

public class BigEnemy : Enemy
{
    private float timer1;
    private float coolDown1 = 0.5f;
    void Start()
    {
        speed = 0.5f;
        atack = 6;
        health = 125;
        resistanceMose = 0.5f;
        rigidbodyUnit = GetComponent<Rigidbody2D>();
    }
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
                ChangeHealth(-GameController.damageClick);
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
