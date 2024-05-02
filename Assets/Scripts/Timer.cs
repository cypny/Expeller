using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeStart = 60;
    public Text timerText;
    
    void Start()
    {
        timerText.text = timeStart.ToString(CultureInfo.InvariantCulture);
    }

    void Update()
    {
        timeStart -= Time.deltaTime;
        timerText.text = Mathf.Round(timeStart).ToString(CultureInfo.InvariantCulture);
    }
}