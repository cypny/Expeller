using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTimer : MonoBehaviour
{
    public bool start;
    public float timeStart;
    public Image timerBar;
    public Canvas speedUI;
    public void TimerStart()
    {
        start = true;
        timerBar.fillAmount = 1;
        GameController.speedClick*= 2;
        speedUI.enabled = true;
    }

    public void TimerStop()
    {
        GameController.speedClick /= 2;
        speedUI.enabled = false;
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
