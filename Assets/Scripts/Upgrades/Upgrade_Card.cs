using UnityEngine;
using TMPro;
using System.Collections;

public class Upgrade_Card : MonoBehaviour
{
    [Header("Card")]
    [SerializeField] public Upgrades Card;
    [SerializeField] float Price;
    [SerializeField] public bool IsSell = false;

    [Header("ref Objects")]
    [SerializeField] Coin_Object Coins;
    [SerializeField] Upgrade_Object AllUpgrades;

    [Header("ref")]
    [SerializeField] Shop_Inventory inventory;
    [SerializeField] GameObject BuyPrice;
    [SerializeField] TextMeshProUGUI BuyPriceText;
    [SerializeField] GameObject SellPrice;
    [SerializeField] TextMeshProUGUI SellPriceText;

    private void Start()
    {
        BuyPriceText.text = Price.ToString();
        SellPriceText.text = (Mathf.FloorToInt(Price / 2)).ToString();

        if (IsSell)
        {
            SellPrice.SetActive(true);
            BuyPrice.SetActive(false);
        }
        else
        {
            SellPrice.SetActive(false);
            BuyPrice.SetActive(true);
        }
    }

    public void Click()
    {
        if (IsSell)
        {
            Sell();
        }
        else
        {
            Buy();
        }
    }

    public void Buy()
    {
        if (Coins.CanBuy(Price) && AllUpgrades.NumberOfUpgrades < AllUpgrades.UpgradeCap)
        {
            Coins.RemoveCoin(Price);
            AllUpgrades.NumberOfUpgrades++;

            switch (Card)
            {
                case Upgrades.TinyBallMulti:
                    AllUpgrades.TinyBallMulti = true;
                    break;
                case Upgrades.SmallBallMulti:
                    AllUpgrades.SmallBallMulti = true;
                    break;
                case Upgrades.MediumBallMulti:
                    AllUpgrades.MediumBallMulti = true;
                    break;
                case Upgrades.LargeBallMulti:
                    AllUpgrades.LargeBallMulti = true;
                    break;
                case Upgrades.HugeBallMulti:
                    AllUpgrades.HugeBallMulti = true;
                    break;
                case Upgrades.MegaBallMulti:
                    AllUpgrades.MegaBallMulti = true;
                    break;
                case Upgrades.GoldBallMulti:
                    AllUpgrades.GoldBallMulti = true;
                    break;
                case Upgrades.ResizeBallMulti:
                    AllUpgrades.ResizeBallMulti = true;
                    break;
                case Upgrades.TinyBallScore:
                    AllUpgrades.TinyBallScore = true;
                    break;
                case Upgrades.SmallBallScore:
                    AllUpgrades.SmallBallScore = true;
                    break;
                case Upgrades.MediumBallScore:
                    AllUpgrades.MediumBallScore = true;
                    break;
                case Upgrades.LargeBallScore:
                    AllUpgrades.LargeBallScore = true;
                    break;
                case Upgrades.HugeBallScore:
                    AllUpgrades.HugeBallScore = true;
                    break;
                case Upgrades.MegaBallScore:
                    AllUpgrades.MegaBallScore = true;
                    break;
                case Upgrades.GoldBallScore:
                    AllUpgrades.GoldBallScore = true;
                    break;
                case Upgrades.ResizeBallScore:
                    AllUpgrades.ResizeBallScore = true;
                    break;
            }

            StartCoroutine(UpdateInventory());
        }
    }

    public void Sell()
    {
        Coins.AddCoin(Mathf.FloorToInt(Price / 2));
        AllUpgrades.NumberOfUpgrades--;

        switch (Card)
        {
            case Upgrades.TinyBallMulti:
                AllUpgrades.TinyBallMulti = false;
                break;
            case Upgrades.SmallBallMulti:
                AllUpgrades.SmallBallMulti = false;
                break;
            case Upgrades.MediumBallMulti:
                AllUpgrades.MediumBallMulti = false;
                break;
            case Upgrades.LargeBallMulti:
                AllUpgrades.LargeBallMulti = false;
                break;
            case Upgrades.HugeBallMulti:
                AllUpgrades.HugeBallMulti = false;
                break;
            case Upgrades.MegaBallMulti:
                AllUpgrades.MegaBallMulti = false;
                break;
            case Upgrades.GoldBallMulti:
                AllUpgrades.GoldBallMulti = false;
                break;
            case Upgrades.ResizeBallMulti:
                AllUpgrades.ResizeBallMulti = false;
                break;
            case Upgrades.TinyBallScore:
                AllUpgrades.TinyBallScore = false;
                break;
            case Upgrades.SmallBallScore:
                AllUpgrades.SmallBallScore = false;
                break;
            case Upgrades.MediumBallScore:
                AllUpgrades.MediumBallScore = false;
                break;
            case Upgrades.LargeBallScore:
                AllUpgrades.LargeBallScore = false;
                break;
            case Upgrades.HugeBallScore:
                AllUpgrades.HugeBallScore = false;
                break;
            case Upgrades.MegaBallScore:
                AllUpgrades.MegaBallScore = false;
                break;
            case Upgrades.GoldBallScore:
                AllUpgrades.GoldBallScore = false;
                break;
            case Upgrades.ResizeBallScore:
                AllUpgrades.ResizeBallScore = false;
                break;
        }

        StartCoroutine(UpdateInventory());
    }

    public IEnumerator UpdateInventory()
    {
        yield return new WaitForSeconds(0.25f);
        inventory.UpdateCards();

        Destroy(gameObject);
    }
}
