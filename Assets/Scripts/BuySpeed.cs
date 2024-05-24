using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuySpeed : MonoBehaviour
{
    public int Price = 175;
    public Text priceText;
    [SerializeField] private AudioSource buySound;
    [SerializeField] private AudioSource notEnoughMoneySound;


    public SpeedTimer SpeedTimer;
    public void Buy()
    {
        if (CoinText.Coin < Price || SpeedTimer.start == true)
        {
            notEnoughMoneySound.Play();
            return;
        }
        buySound.Play();
        CoinText.Coin -= Price;
        Price += 75;
        priceText.text = Price.ToString();
        GameController.speedClick += 1;
    }
}

