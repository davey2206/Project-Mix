using UnityEngine;

public class Bowl_Size_Upgrades : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Upgrade_Card Card;

    public void Basic()
    {
        if (!Card.IsSell && Card.CanUpgrade())
        {
            Upgrades.ChangeBowlSize(1);
        }
        
        if(Card.IsSell)
        {
            Upgrades.ChangeBowlSize(-1);
        }
    }

    public void SizeForBallSize()
    {
        if (!Card.IsSell && Card.CanUpgrade())
        {
            Upgrades.ChangeBowlSize(1);
            Upgrades.ChangeBallSize(0.2f);
        }
        
        if (Card.IsSell)
        {
            Upgrades.ChangeBowlSize(-1);
            Upgrades.ChangeBallSize(-0.2f);
        }
    }

    public void BowlExtraSlot()
    {
        if (!Card.IsSell && Card.CanUpgrade())
        {
            Upgrades.ChangeSlots(1);
            Upgrades.ChangeBowlSize(1);
        }
        
        if (Card.IsSell)
        {
            Upgrades.ChangeBowlSize(-1);
            Upgrades.ChangeSlots(-1);
        }
    }
}
