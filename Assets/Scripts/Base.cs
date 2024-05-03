using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public HealthBar healthbar;
    public float health = 20;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            healthbar.ValueChange(other.gameObject.GetComponent<Enemy>().GetAtk());
            Destroy(other.gameObject);
        }
            
    }
    
}
