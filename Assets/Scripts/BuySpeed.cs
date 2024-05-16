using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuySpeed : MonoBehaviour
{
    public int Price = 175;
    public CoinText CoinText;
    public Canvas speedUI;
    public Image timerBar;
    public void Buy()
    {
        if (CoinText.Coin < Price) return;
        CoinText.Coin -= Price;
        Unit.moseSpeed *= 2;
        speedUI.enabled = true;
        timerBar.fillAmount = 1;
    }
}

