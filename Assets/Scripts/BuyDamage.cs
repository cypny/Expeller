using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyDamage : MonoBehaviour
{
    public int Price = 175;
    public Text priceText;
    [SerializeField] private AudioSource buySound;
    [SerializeField] private AudioSource notEnoughMoneySound;


    public DamageTimer DamageTimer;
    public void Buy()
    {
        if (CoinText.Coin < Price || DamageTimer.start == true)
        {
            notEnoughMoneySound.Play();
            return;
        }
        buySound.Play();
        CoinText.Coin -= Price;
        Price += 75;
        priceText.text = Price.ToString();
        GameController.damageClick += 2;
    }
}
