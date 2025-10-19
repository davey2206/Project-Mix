using UnityEngine;

public class Ball_Size_Upgrades : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Upgrade_Card Card;

    public void Basic()
    {
        if (!Card.IsSell && Card.CanUpgrade())
        {
            Upgrades.ChangeBallSize(-0.2f);
        }
        if(Card.IsSell)
        {
            Upgrades.ChangeBallSize(0.2f);
        }
    }

    public void SizeForBowlSize()
    {
        if (!Card.IsSell && Card.CanUpgrade())
        {
            Upgrades.ChangeBowlSize(-1);
            Upgrades.ChangeBallSize(-0.2f);
        }

        if(Card.IsSell)
        {
            Upgrades.ChangeBowlSize(1);
            Upgrades.ChangeBallSize(0.2f);
        }
    }

    public void TinyierTiny()
    {
        if (!Card.IsSell && Card.CanUpgrade())
        {
            Upgrades.ChangeBallSize(-0.2f);
        }
        if (Card.IsSell)
        {
            Upgrades.ChangeBallSize(0.2f);
        }
    }
}
