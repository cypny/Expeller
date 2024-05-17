using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private float health = 200;
    private float timer;
    private float coolDown = .5f;
    public Sprite spritewall;
    void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                timer = coolDown;
                TakeDamage(other.gameObject.GetComponent<Unit>().GetAtk());
            }
        }
    }
    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}


