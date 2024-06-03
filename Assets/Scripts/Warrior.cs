using System;
using System.Linq;
using UnityEngine;

public class Warrior : Unit
{
    private float timerAbility =5;
    private float coolDownAbility = 5;
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
        if (timerAbility  > 0)
        {
            timerAbility  -= Time.deltaTime;
        }
        if (timerAbility  <= 0)
        {
            timerAbility  = coolDownAbility;
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
                .Select(x => ((GetDistantion(x.position,rigidbodyUnit.position), x)))
                .OrderBy(x => x.Item1)
                .Take(1)
                .Select(x => x.Item2)
                .ToList()[0];
        }
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
