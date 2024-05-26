using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinText : MonoBehaviour
{
    private Text CoinTexts;
    public static int Coin=1000;

    private void Start()
    {
        CoinTexts = GetComponent<Text>();
        Coin = PlayerPrefs.GetInt("Coins", Coin);
    }

    private void Update()
    {
        CoinTexts.text = Coin.ToString();
    }
}
