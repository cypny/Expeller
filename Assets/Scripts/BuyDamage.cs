using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyDamage : MonoBehaviour
{
    public int Price = 175;
    public DamageTimer DamageTimer;
    public void Buy()
    {
        if (CoinText.Coin < Price)
        {
            notEnoughMoneySound.Play();
            return;
        }
        buySound.Play();
        CoinText.Coin -= Price;
        DamageTimer.TimerStart();
    }
}
