using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    private float timer;
    private float coolDown = 0.5f;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerUnit")
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                timer = coolDown;
                ChangeHealth(-other.gameObject.GetComponent<Unit>().GetAtk());
            }
        }
    }
}
