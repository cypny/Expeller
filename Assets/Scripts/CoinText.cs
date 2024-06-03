using UnityEngine;
using UnityEngine.UI;
public class CoinText : MonoBehaviour
{
    private Text CoinTexts;
    public static int Coin=0;

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
