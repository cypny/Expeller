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
    public Text priceText;
    [SerializeField] private AudioSource buySound;
    [SerializeField] private AudioSource notEnoughMoneySound;


    public void Buy()
    {
        if (CoinText.Coin < Price)
        {
            notEnoughMoneySound.Play();
            return;
        }
        buySound.Play();
        CoinText.Coin -= Price;
        Price += 75;
        priceText.text = Price.ToString();
        Unit.moseSpeed *= 2;
        speedUI.enabled = true;
        timerBar.fillAmount = 1;
    }
}

