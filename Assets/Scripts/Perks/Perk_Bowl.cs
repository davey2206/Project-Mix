using UnityEngine;

public class Perk_Bowl : MonoBehaviour
{
    [SerializeField] Perks_Object Perks;
    [SerializeField] Upgrade_Object Upgrades;

    private bool biggerBowl = false;

    private void Awake()
    {
        biggerBowl = false;
    }

    public void BowlEffects()
    {
        BiggerBowl();
    }

    private void BiggerBowl()
    {
        if (Perks.BiggerBowl && !biggerBowl)
        {
            Upgrades.ChangeBowlSize(1);
            biggerBowl = true;
        }
    }
}
