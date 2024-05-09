using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public HealthBar healthbar;
    public float health = 20;
    public int coins;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            healthbar.ValueChange(other.gameObject.GetComponent<Unit>().GetAtk());
            Destroy(other.gameObject);
        }
            
    }
    
}
