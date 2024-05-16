using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTimer : MonoBehaviour
{
    public float timeStart;
    public Image timerBar;
    public Canvas speedUI;
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
            Unit.moseSpeed /= 2;
            speedUI.enabled = false;
            timeStart = 15;
        }
    }
}
