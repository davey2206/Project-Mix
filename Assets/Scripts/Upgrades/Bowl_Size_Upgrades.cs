using UnityEngine;

public class Bowl_Size_Upgrades : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Upgrade_Card Card;

    public void Basic()
    {
        if (!Card.IsSell)
        {
            Upgrades.ChangeBowlSize(1);
        }
        else 
        {
            Upgrades.ChangeBowlSize(-1);
        }
    }

    public void SizeForBallSize()
    {
        if (!Card.IsSell)
        {
            Upgrades.ChangeBowlSize(1);
            Upgrades.ChangeBallSize(0.2f);
        }
        else
        {
            Upgrades.ChangeBowlSize(-1);
            Upgrades.ChangeBallSize(-0.2f);
        }
    }
}
