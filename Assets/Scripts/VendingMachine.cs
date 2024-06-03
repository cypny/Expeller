using System.Linq;
using UnityEngine;

public class VendingMachine : Unit
{
    // Start is called before the first frame update
    private float timerAbility = 5;
    private float timerTakeDamage = 1;
    private float coolDownAbility = 5;
    private float coolDownTakeDamage = 0.5f;
    private float damagePower = 5;
    private float radius = 10;
    public GameObject aura;
    void Start()
    {
        rigidbodyUnit = GetComponent<Rigidbody2D>();
        health = 20;
        atack = 0;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (timerTakeDamage > 0)
            {
                timerTakeDamage -= Time.deltaTime;
            }
            if (timerTakeDamage <= 0)
            {
                timerTakeDamage = coolDownTakeDamage;
                ChangeHealth(-other.gameObject.GetComponent<Unit>().GetAtk());
            }
        }
    }
    void FixedUpdate()
    {
        if (timerAbility > 0)
        {
            timerAbility -= Time.deltaTime;
        }
        if (timerAbility <= 0)
        {
            timerAbility = coolDownAbility;
            UseAbility();
        }
        rigidbodyUnit.velocity = new Vector2(0, 0);
        if (isTargetMouse)
        {
            MovetoMouse();
            if (!Input.GetMouseButton(0))
            {
                isTargetMouse = false;
            }
        }
    }

    private void DamageObject(GameObject obj)
    {
        obj.gameObject.GetComponent<Unit>().ChangeHealth(-damagePower);
    }
    private void OffAura()
    {
        aura.SetActive(false);
    }
    private void UseAbility()
    {
        aura.SetActive(true);
        Invoke("OffAura", 0.25f);
        var enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys.Count() != 0)
        {
            enemys = enemys
                .Where(x => x != this.gameObject)
                .Where(x => (GetDistantion(x.transform.position, rigidbodyUnit.position) <= radius))
                .ToArray();
            if (enemys.Count() != 0)
            {
                foreach (var enemy in enemys)
                {
                    DamageObject(enemy);
                }
            }
        }
    }

}
