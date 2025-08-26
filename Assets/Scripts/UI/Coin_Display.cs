using TMPro;
using UnityEngine;

public class Coin_Display : MonoBehaviour
{
    [SerializeField] Coin_Object Coins;
    [SerializeField] TextMeshProUGUI CoinText;

    void Update()
    {
        CoinText.text = Coins.GetCoin().ToString();
    }
}
