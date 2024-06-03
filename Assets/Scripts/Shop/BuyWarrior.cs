using UnityEngine;
using UnityEngine.UI;


public class BuyWarrior : MonoBehaviour
{
    public int price = 400;
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
            price = 200+ (int)Mathf.Round(price*1.5f);
            price = price - price % 5;
            priceText.text = price.ToString();
            storeCanvas.enabled = false;
            gameCanvas.enabled = true;
            GameController.isBuyWarrior = true;
        }
        else
        {
            notEnoughMoneySound.Play();
        }
    }
}
