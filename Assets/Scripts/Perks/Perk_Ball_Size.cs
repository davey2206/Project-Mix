using UnityEngine;

public class Perk_Ball_Size : MonoBehaviour
{
    [SerializeField] Perks_Object Perks;
    [SerializeField] Upgrade_Object Upgrades;

    private bool smallerBalls = false;

    private void Awake()
    {
        smallerBalls = false;
    }

    public void BallSizeEffects()
    {
        SmallerBalls();
    }

    private void SmallerBalls()
    {
        if (Perks.SmallerBalls && !smallerBalls)
        {
            Upgrades.ChangeBallSize(-0.25f);
            smallerBalls = true;
        }
    }
}
