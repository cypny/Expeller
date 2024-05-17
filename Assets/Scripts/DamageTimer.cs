using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTimer : MonoBehaviour
{
    public bool start;
    public float timeStart;
    public Image timerBar;
    public Canvas damageUI;
    public void TimerStart()
    {
        start = true;
        timerBar.fillAmount = 1;
        GameController.damageClick += 1;
        damageUI.enabled = true;
    }

    public void TimerStop()
    {
        GameController.damageClick -= 1;
        damageUI.enabled = false;
        start = false;
        timeStart = 15;
        timerBar.fillAmount = 1;
    }
    void Update()
    {
        if (start)
        {
            timeStart -= Time.deltaTime;
            timerBar.fillAmount = timeStart / 15;
        }
        
        if (timerBar.fillAmount == 0)
        {
            TimerStop();
        }
    }
}