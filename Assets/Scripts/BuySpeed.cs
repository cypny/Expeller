using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySpeed : MonoBehaviour
{
    public int Price = 150;
    public CoinText CoinText;

    private void TryBuy()
    {
        if (CoinText.Coin >= Price)
            Buy();
        else
            ShowPopupWindow();
    }

    private void Buy()
    {
        
    }
    
    private void ShowPopupWindow()
    {
        
    }
}

