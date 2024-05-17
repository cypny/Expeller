using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyWall : MonoBehaviour
{
    public int Price = 250;
    public CoinText CoinText;
    public Canvas gameCanvas;
    public Canvas storeCanvas;
    public Text priceText;
    [SerializeField] private AudioSource buySound;
    [SerializeField] private AudioSource notEnoughMoneySound;

    public void Buy()
    {
        if (CoinText.Coin >= Price)
        {
            buySound.Play();
            CoinText.Coin -= Price;
            Price += 75;
            priceText.text = Price.ToString();
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
