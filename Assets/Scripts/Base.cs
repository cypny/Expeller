using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other, HealthBar bar)
    {
        if (other.gameObject.tag == "Enemy")
            Destroy(other.gameObject);
    }
    
}
