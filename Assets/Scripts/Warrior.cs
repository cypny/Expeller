using System;
using System.Linq;
using UnityEngine;

public class Warrior : Unit
{
    private float timer=5;
    private float coolDown = 5;
    private bool ischarge;
    void Start()
    {
        ischarge = false;
        speed = 0.1f;
        atack = 2;
        health = 200;
        rigidbodyUnit = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (target == null)
        {
            rigidbodyUnit.velocity = new Vector2(0, 0);
            FindTarget();
        }
        if (target != null && !ischarge)
        {
            MoveToTarget();
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            timer = coolDown;
            FindTarget();
            Charge();
        }
        if (isTargetMouse)
        {
            MovetoMouse();
            if (!Input.GetMouseButton(0))
            {
                isTargetMouse = false;
            }
        }
    }

    private void FindTarget()
    {
        var enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys.Count() != 0)
        {
            target = enemys
                .Select(x => x.transform)
                .Select(x => ((FindDistant(x), x)))
                .OrderBy(x => x.Item1)
                .Take(1)
                .Select(x => x.Item2)
                .ToList()[0];
        }
    }
    private float FindDistant(Transform target)
    {
        var first = target.position;
        var second = rigidbodyUnit.position;
        var rez = new Vector2();
        rez.x = first.x - second.x;
        rez.y = first.y - second.y;
        return (float)Math.Sqrt(rez.x * rez.x + rez.y * rez.y);
    }
    private void MoveToTarget()
    {
        moveTargetVector = GetOrtVectorInPosition(target.position, rigidbodyUnit.position);
        rigidbodyUnit.velocity = moveTargetVector * speed;
    }
    private void Charge()
    {
        atack = 25;
        ischarge = true;
        rigidbodyUnit.velocity = moveTargetVector * 10;
        Invoke("StopCharge", 0.25f);
    }
    private void StopCharge()
    {
        atack = 2;
        ischarge = false;
    }
}
