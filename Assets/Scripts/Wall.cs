using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{
    private float health = 200;
    private float maxhealth = 150;
    private float timer;
    private float coolDown = 0.5f;
    private SpriteRenderer img;
    [SerializeField] private Sprite spritewall1;
    [SerializeField] private Sprite spritewall2;
    [SerializeField] private Sprite spritewall3;
    void Start()
    {
        health = maxhealth;
        img = GetComponent<SpriteRenderer>();
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
        if (health <= maxhealth/4*3 && health >= maxhealth/4*2)
        {
            img.sprite = spritewall1;
        }
        else if (health<= maxhealth / 4 * 2 && health >= maxhealth / 4)
        {
            img.sprite = spritewall2;
        }
        else if (health <= maxhealth / 4) 
        {
            img.sprite = spritewall3;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}


