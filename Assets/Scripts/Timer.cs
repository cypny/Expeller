using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static float time = 60;
    private static bool isRun = false;
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
                isRun = false;
            }
        }
    }
    public static void PlayorStop()
    {
        isRun = !isRun;
    }
    public static void SetTime(float timeset)
    {
        time = timeset;
    }
    public static float GetTime()
    {
        return time;
    }
}


