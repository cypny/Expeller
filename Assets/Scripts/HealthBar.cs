using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image bar;
    private float health;
    public float maxhealth;
    [SerializeField] private AudioSource lose;
    public GameObject end;
    public void Start()
    {
        health = maxhealth;
        bar.fillAmount = 1;
    }

    public void ValueChange(float damage)
    {
        bar.fillAmount -= damage / maxhealth;
        health -= damage;
        if (health <= 0)
        {
            end.SetActive(true);
            lose.Play();
            Invoke("End",3);
        }
    }
    private void End()
    {
        Application.Quit();
    }
}
