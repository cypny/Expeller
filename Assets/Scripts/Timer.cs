using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float time = 60;
    public bool isRun = false;
    public Text timerText;
    public GameController controller;
    void Start()
    {
        timerText.text = time.ToString(CultureInfo.InvariantCulture);
    }

    void Update()
    {
        if (isRun)
        {
            time -= Time.deltaTime;
            timerText.text = Mathf.Round(time).ToString(CultureInfo.InvariantCulture);
            if (time <= 0)
            {
                controller.EndWave();
                time = 60;
                isRun = false;
            }
        }
    }
}


