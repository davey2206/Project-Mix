using UnityEngine;

public class Card_Slot_Upgrade : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;

    public void BasicExtraSlot()
    {
        Upgrades.UpgradeCap += 2;
    }
}
