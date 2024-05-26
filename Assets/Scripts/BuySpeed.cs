using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuySpeed : MonoBehaviour
{
    public int price = 175;
    public Text priceText;
    [SerializeField] private AudioSource buySound;
    [SerializeField] private AudioSource notEnoughMoneySound;


    public SpeedTimer SpeedTimer;
    public void Buy()
    {
        if (CoinText.Coin < price || SpeedTimer.start == true)
        {
            notEnoughMoneySound.Play();
            return;
        }
        buySound.Play();
        CoinText.Coin -= price;
        price += 10 + (int)Mathf.Round(price * 1.1f);
        priceText.text = price.ToString();
        GameController.speedClick += 1;
    }
}

