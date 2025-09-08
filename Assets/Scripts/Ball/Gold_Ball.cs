using UnityEngine;

public class Gold_Ball : MonoBehaviour
{
    [SerializeField] Coin_Object Coin;
    [SerializeField] float Coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boll"))
        {
            Coin.LevelCoin += Coins;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Boll"))
        {
            Coin.LevelCoin -= Coins;
        }
    }
}
