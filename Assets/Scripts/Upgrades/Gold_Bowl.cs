using UnityEngine;

public class Gold_Bowl : MonoBehaviour
{
    [SerializeField] Coin_Object Coins;
    [SerializeField] Upgrade_Object Upgrades;

    private int lastThreshold = 0;

    void Update()
    {
        if (Upgrades.GoldenBowl)
        {
            UpdateBowlSize();
        }
    }

    void UpdateBowlSize()
    {
        int newThreshold = (int)Coins.GetCoin() / 50;

        if (newThreshold != lastThreshold)
        {
            int difference = newThreshold - lastThreshold;
            Upgrades.ChangeBowlSize(difference);
            lastThreshold = newThreshold;
        }
    }
}
