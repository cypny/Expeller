using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyDamage : MonoBehaviour
{
    public int price = 175;
    public Text priceText;
    [SerializeField] private AudioSource buySound;
    [SerializeField] private AudioSource notEnoughMoneySound;


    public DamageTimer DamageTimer;
    public void Buy()
    {
        if (CoinText.Coin < price || DamageTimer.start == true)
        {
            notEnoughMoneySound.Play();
            return;
        }
        buySound.Play();
        CoinText.Coin -= price;
        price += 10 + (int)Mathf.Round(price * 1.1f); ;

        priceText.text = price.ToString();
        GameController.damageClick += 1;
    }
}
