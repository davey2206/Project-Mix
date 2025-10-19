using UnityEngine;

public class Perk_Slot : MonoBehaviour
{
    [SerializeField] Perks_Object Perks;
    [SerializeField] Upgrade_Object Upgrades;

    private bool Slot = false;

    private void Awake()
    {
        Slot = false;
    }

    public void SlotEffects()
    {
        ExtraSlot();
    }

    private void ExtraSlot()
    {
        if (Perks.ExtraSlot && !Slot)
        {
            Upgrades.ChangeSlots(1);
            Slot = true;
        }
    }
}
