using UnityEngine;

public class Gold_Slot_Sell : MonoBehaviour
{
    [SerializeField] Coin_Object Coins;
    [SerializeField] Upgrade_Card Card;
    [SerializeField] Upgrade_Object Upgrades;

    public void SellGoldSlot()
    {
        if (Card.IsSell)
        {
            Upgrades.ChangeSlots(-Upgrades.UpgradeCapGoldChange);
        }
    }
}
