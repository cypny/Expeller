using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTimer : MonoBehaviour
{
    public float timeStart;
    public Image timerBar;
    public Canvas damageUI;
    void Start()
    {
        timerBar.fillAmount = 1;
    }

    void Update()
    {
        timeStart -= Time.deltaTime;
        timerBar.fillAmount = timeStart / 15;
        if (timerBar.fillAmount == 0)
        {
            GameController.damageClick -= 1;
            damageUI.enabled = false;
            timeStart = 15;
        }
            
    }
}