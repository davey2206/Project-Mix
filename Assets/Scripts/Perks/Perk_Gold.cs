using UnityEngine;

public class Perk_Gold : MonoBehaviour
{
    [SerializeField] Perks_Object Perks;
    [SerializeField] Coin_Object Coins;

    private bool Gold1 = false;
    private bool Gold2 = false;
    private bool Gold3 = false;

    private void Awake()
    {
        Gold1 = false;
        Gold2 = false;
        Gold3 = false;
    }

    public void GoldEffects()
    {
        GainGold();
    }

    private void GainGold()
    {
        if (Perks.GainGold1 && !Gold1)
        {
            Coins.AddCoin(5);
            Gold1 = true;
        }
        if (Perks.GainGold2 && !Gold2)
        {
            Coins.AddCoin(5);
            Gold2 = true;
        }
        if (Perks.GainGold3 && !Gold3)
        {
            Coins.AddCoin(5);
            Gold3 = true;
        }
    }
}
