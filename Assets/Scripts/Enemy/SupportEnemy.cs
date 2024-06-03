using System.Linq;
using UnityEngine;

public class Supportenemy : Enemy
{
    private float timerAbility=1;
    private float coolDownAbility =3;
    private float timer1;
    private float speedPower =0.5f;
    private float radius = 7.4f;
    private float coolDown1 = 0.5f;
    private Transform currenttarget;
    public GameObject aura;
    void Start()
    {
        currenttarget = target;
        speed = 2;
        atack = 0;
        health = 7;
        resistanceMose = -0.1f;
        rigidbodyUnit = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        FindTarget();
        MoveToTarget();
        if (timerAbility > 0)
        {
            timerAbility -= Time.deltaTime;
        }
        else if (timerAbility <= 0)
        {
            timerAbility = coolDownAbility;
            UseAbility();
        }
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
    private void GiveBuff(GameObject obj)
    {
        obj.gameObject.GetComponent<Unit>().ChangeHealth(health);
        obj.gameObject.GetComponent<Unit>().ChangeSpeed(speedPower);
        
    }
    private void OffAura()
    {
        aura.SetActive(false);
    }
    private void UseAbility()
    {
        aura.SetActive(true);
        Invoke("OffAura", 0.5f);
        var enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys.Count() >1)
        {
            enemys=enemys
                .Where(x => x != this.gameObject)
                .Where(x => (GetDistantion(x.transform.position, rigidbodyUnit.position) <= radius))
                .ToArray();
            if (enemys.Count() != 0)
            {
                foreach (var enemy in enemys)
                {
                    GiveBuff(enemy);
                }
            }   
         }
    }
    private void FindTarget()
    {
        var enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys.Count() >1)
        {
            currenttarget = enemys
                .Where(x=>x!=this.gameObject)
                .Select(x => x.transform)
                .Select(x => ((GetDistantion(x.position, rigidbodyUnit.position), x)))
                .OrderBy(x => x.Item1)
                .Take(1)
                .Select(x => x.Item2)
                .ToList()[0];
        }
        else
        {
            currenttarget = target;
        }
    }
    private void MoveToTarget()
    {
        moveTargetVector = GetOrtVectorInPosition(currenttarget.position, rigidbodyUnit.position);
        rigidbodyUnit.velocity = moveTargetVector * speed;
    }
}
