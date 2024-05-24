using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public HealthBar healthbar;
    public float health = 200;
    public int coins;
    private bool isTakeDamage=false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && !isTakeDamage)
        {
            isTakeDamage= true;
            Destroy(other.gameObject);
            healthbar.ValueChange(other.gameObject.GetComponent<Unit>().GetAtk());
            GameController.countEnemy -= 1;
            isTakeDamage=false;
        }
            
    }
    
}
