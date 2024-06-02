using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyWall : MonoBehaviour
{
    public int price;
    public CoinText CoinText;
    public Canvas gameCanvas;
    public Canvas storeCanvas;
    public Text priceText;
    [SerializeField] private AudioSource buySound;
    [SerializeField] private AudioSource notEnoughMoneySound;

    public void Buy()
    {
        if (CoinText.Coin >= price)
        {
            buySound.Play();
            CoinText.Coin -= price;
            price += 50 + (int)Mathf.Round(price * 0.25f);
            priceText.text = price.ToString();
            storeCanvas.enabled = false;
            
            gameCanvas.enabled = true;
            GameController.isBuyWall = true;
        }
        else
        {
            notEnoughMoneySound.Play();
        }
    }
}
