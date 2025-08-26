using UnityEngine;

public class Active_Ball : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Spawner_Order Order;

    public void SetBomb()
    {
        Order.SetBomb();
        Upgrades.DeleteBall--;
    }

    public void SetResize()
    {
        Order.SetResize();
        Upgrades.ResizeBall--;
    }

    public void SetGold()
    {
        Order.SetGold();
        Upgrades.GoldBall--;
    }
}
