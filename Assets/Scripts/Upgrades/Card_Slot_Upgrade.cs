using UnityEngine;

public class Card_Slot_Upgrade : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Upgrade_Card Card;

    public void BasicExtraSlot()
    {
        if (!Card.IsSell && Card.CanUpgrade())
        {
            Upgrades.ChangeSlots(2);
        }
        if (Card.IsSell)
        {
            Upgrades.ChangeSlots(-2);
        }
    }
}
