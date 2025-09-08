using TMPro;
using UnityEngine;

public class Active_Ball_Shop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CostText;
    [SerializeField] TextMeshProUGUI OwnedText;
    [SerializeField] Coin_Object Coins;
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] float BaseCost;
    [SerializeField] bool IsBomb = false;
    [SerializeField] bool IsResize = false;
    [SerializeField] bool IsGold = false;
    float Cost;

    private void OnEnable()
    {
        Cost = BaseCost;
    }

    public void Click()
    {
        if (Coins.CanBuy(Cost))
        {
            Coins.RemoveCoin(Cost);

            if (IsBomb)
            {
                Upgrades.DeleteBall++;
            }
            if (IsResize)
            {
                Upgrades.ResizeBall++;
            }
            if (IsGold)
            {
                Upgrades.GoldBall++;
            }

            Cost = Cost * 2;
        }
    }

    private void Update()
    {
        CostText.text = Cost.ToString();

        if (IsBomb)
        {
            OwnedText.text = Upgrades.DeleteBall.ToString();
        }

        if (IsResize)
        {
            OwnedText.text = Upgrades.ResizeBall.ToString();
        }

        if (IsGold)
        {
            OwnedText.text = Upgrades.GoldBall.ToString();
        }
    }
}
