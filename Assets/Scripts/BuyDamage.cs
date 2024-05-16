using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyDamage : MonoBehaviour
{
    public int Price = 175;
    public CoinText CoinText;
    public Canvas damageUI;
    public Image timerBar;
    public void Buy()
    {
        if (CoinText.Coin < Price) return;
        CoinText.Coin -= Price;
        GameController.damageClick += 1;
        damageUI.enabled = true;
        timerBar.fillAmount = 1;
    }
}
