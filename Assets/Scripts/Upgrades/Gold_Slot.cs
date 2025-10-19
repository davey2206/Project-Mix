using UnityEngine;

public class Gold_Slot : MonoBehaviour
{
    [SerializeField] Coin_Object Coins;
    [SerializeField] Upgrade_Object Upgrades;

    private int lastThreshold = 0;

    void Update()
    {
        if (Upgrades.GoldenSlot)
        {
            UpdateSlots();
        }
    }

    void UpdateSlots()
    {
        int newThreshold = (int)Coins.GetCoin() / 5;

        if (newThreshold >= 5)
        {
            Upgrades.UpgradeCapGoldChange = 5;

            newThreshold = 5;

            if (newThreshold != lastThreshold)
            {
                int difference = newThreshold - lastThreshold;
                Upgrades.ChangeSlots(difference);
                lastThreshold = newThreshold;
            }
        }
        else
        {
            Upgrades.UpgradeCapGoldChange = newThreshold;

            if (newThreshold != lastThreshold)
            {
                int difference = newThreshold - lastThreshold;
                Upgrades.ChangeSlots(difference);
                lastThreshold = newThreshold;
            }
        }
    }
}
