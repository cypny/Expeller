using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyDamage : MonoBehaviour
{
    public int Price = 175;
    public CoinText CoinText;

    public void Buy()
    {
        if (CoinText.Coin >= Price)
        {
            CoinText.Coin -= Price;
        }
    }
}
