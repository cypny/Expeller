using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyWall : MonoBehaviour
{
    public int Price = 250;
    public CoinText CoinText;
    public Canvas gameCanvas;
    public Canvas storeCanvas;

    public void Buy()
    {
        if (CoinText.Coin >= Price)
        {
            CoinText.Coin -= Price;
            storeCanvas.enabled = false;
            gameCanvas.enabled = true;
            GameController.isBuyWall = true;
        }
    }
}
