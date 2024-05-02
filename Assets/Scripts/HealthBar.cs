using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image bar;
    public float fill;
    
    public void Start()
    {
        bar.fillAmount = 1;
    }

    public void ValueChange(float damage)
    {
        bar.fillAmount -= damage /25;
    }
}
