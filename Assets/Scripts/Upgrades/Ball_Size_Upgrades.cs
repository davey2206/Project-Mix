using UnityEngine;

public class Ball_Size_Upgrades : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Upgrade_Card Card;

    public void Basic()
    {
        if (!Card.IsSell)
        {
            Upgrades.ChangeBallSize(-0.2f);
        }
        else
        {
            Upgrades.ChangeBallSize(0.2f);
        }
    }

    public void SizeForBowlSize()
    {
        if (!Card.IsSell)
        {
            Upgrades.ChangeBowlSize(-1);
            Upgrades.ChangeBallSize(-0.2f);
        }
        else
        {
            Upgrades.ChangeBowlSize(1);
            Upgrades.ChangeBallSize(0.2f);
        }
    }
}
