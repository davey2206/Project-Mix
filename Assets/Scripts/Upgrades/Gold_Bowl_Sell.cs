using UnityEngine;

public class Gold_Bowl_Sell : MonoBehaviour
{
    [SerializeField] Coin_Object Coins;
    [SerializeField] Upgrade_Card Card;
    [SerializeField] Upgrade_Object Upgrades;

    public void SellGoldBowl()
    {
        if (Card.IsSell)
        {
            Upgrades.ChangeBowlSize(-Upgrades.BowlGoldChange);
        }
    }
}
