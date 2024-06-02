using UnityEngine;

public class SpiralEnemy : Enemy
{
    private float timer1;
    private float coolDown1 = 0.5f;
    private float RotationSpeed;
    private float angle=0;
    void Start()
    {
        speed = 2;
        RotationSpeed = speed;
        angle = Random.Range(0, 360);
        atack = 2;
        health = 15;
        rigidbodyUnit = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MoveToTarget();
        MoveCircle();
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
    private void MoveCircle()
    {
        angle += RotationSpeed * Time.deltaTime;
 
        rigidbodyUnit.velocity += new Vector2(Mathf.Cos(angle), Mathf.Sin(angle))*10;
        if (angle >= 361)
        {
            angle = 0;
        }
    }
    private void MoveToTarget()
    {
        moveTargetVector = GetOrtVectorInPosition(target.position, rigidbodyUnit.position);
        rigidbodyUnit.velocity = moveTargetVector * speed;
    }
}
