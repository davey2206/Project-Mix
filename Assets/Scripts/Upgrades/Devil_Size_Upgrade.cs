using UnityEngine;

public class Devil_Size_Upgrade : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Upgrade_Card Card;

    public void ClickDevilSize()
    {
        if (!Card.IsSell && Card.CanUpgrade())
        {
            if (Upgrades.DevilScore && Upgrades.DevilMulti)
            {
                Upgrades.ChangeBallSize(-0.2f);
            }
            else
            {
                Upgrades.ChangeBallSize(0.2f);
            }
        }
        
        if(Card.IsSell)
        {
            if (Upgrades.DevilScore && Upgrades.DevilMulti)
            {
                Upgrades.ChangeBallSize(0.2f);
            }
            else
            {
                Upgrades.ChangeBallSize(-0.2f);
            }
        }
    }

    public void ClickDevilCard()
    {
        if (!Card.IsSell && Card.CanUpgrade())
        {
            if (Upgrades.DevilScore && Upgrades.DevilMulti && Upgrades.DevilSize)
            {
                Upgrades.ChangeBallSize(-0.4f);
            }
        }
        
        if (Card.IsSell)
        {
            if (!(Upgrades.DevilScore && Upgrades.DevilMulti && Upgrades.DevilSize))
            {
                Upgrades.ChangeBallSize(0.4f);
            }
        }
    }
}
