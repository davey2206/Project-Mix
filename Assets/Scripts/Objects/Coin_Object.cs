using UnityEngine;

[CreateAssetMenu(fileName = "Coin", menuName = "ScriptableObjects/Coin_Object", order = 1)]
public class Coin_Object : ScriptableObject
{
    [SerializeField] float Coin;

    public void AddCoin(float coin)
    {
        Coin += coin;
    }
    public void RemoveCoin(float coin)
    {
        Coin -= coin;
    }
    public float GetCoin()
    {
        return Coin;
    }
    public bool CanBuy(float coin)
    {
        if (Coin >= coin)
        {
            return true;
        }

        return false;
    }

    public void ResetCoins()
    {
        Coin = 0;
    }
}
