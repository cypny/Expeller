using UnityEngine;
using UnityEngine.UI;

public class BuyMachine : MonoBehaviour
{
    public int price = 1000;
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
            price = 500 + (int)Mathf.Round(price * 2);
            price = price - price % 5;
            priceText.text = price.ToString();
            storeCanvas.enabled = false;
            gameCanvas.enabled = true;
            GameController.isBuyMachine = true;
        }
        else
        {
            notEnoughMoneySound.Play();
        }
    }
}
