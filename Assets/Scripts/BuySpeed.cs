using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuySpeed : MonoBehaviour
{
    public int Price = 175;
    public SpeedTimer SpeedTimer;
    public void Buy()
    {
        if (CoinText.Coin < Price) return;
        CoinText.Coin -= Price;
        SpeedTimer.TimerStart(); 
    }
}

