using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class Upgrade_Card : MonoBehaviour
{
    [Header("Card")]
    [SerializeField] public Upgrades Card;
    [SerializeField] float Price;
    [SerializeField] public bool IsSell = false;

    [Header("Ref Objects")]
    [SerializeField] Coin_Object Coins;
    [SerializeField] Upgrade_Object AllUpgrades;

    [Header("Ref")]
    [SerializeField] Shop_Inventory inventory;
    [SerializeField] GameObject BuyPrice;
    [SerializeField] TextMeshProUGUI BuyPriceText;
    [SerializeField] GameObject SellPrice;
    [SerializeField] TextMeshProUGUI SellPriceText;

    private Dictionary<Upgrades, System.Action<bool>> upgradeActions;

    private void Start()
    {
        BuyPriceText.text = Price.ToString();
        SellPriceText.text = (Mathf.FloorToInt(Price / 2)).ToString();

        BuyPrice.SetActive(!IsSell);
        SellPrice.SetActive(IsSell);

        InitializeUpgradeActions();
    }

    private void InitializeUpgradeActions()
    {
        upgradeActions = new Dictionary<Upgrades, System.Action<bool>>();

        // Use reflection to get all fields in AllUpgrades
        FieldInfo[] fields = typeof(Upgrade_Object).GetFields(BindingFlags.Public | BindingFlags.Instance);

        // Loop through the enum values and dynamically create upgrade actions
        foreach (Upgrades upgrade in System.Enum.GetValues(typeof(Upgrades)))
        {
            // Build the action for each upgrade
            FieldInfo field = System.Array.Find(fields, f => f.Name == upgrade.ToString());

            if (field != null)
            {
                // Create a lambda function that sets the field to true or false based on the value of the action
                upgradeActions[upgrade] = value => field.SetValue(AllUpgrades, value);
            }
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

    public bool CanUpgrade()
    {
        if (Coins.CanBuy(Price) && AllUpgrades.NumberOfUpgrades < AllUpgrades.UpgradeCap)
        {
            return true;
        }

        return false;
    }

    public void Buy()
    {
        if (CanUpgrade())
        {
            Coins.RemoveCoin(Price);
            AllUpgrades.NumberOfUpgrades++;

            // Apply the upgrade using the dictionary
            ApplyUpgrade(Card, true);

            StartCoroutine(UpdateInventory());
        }
    }

    public void Sell()
    {
        Coins.AddCoin(Mathf.FloorToInt(Price / 2));
        AllUpgrades.NumberOfUpgrades--;

        // Remove the upgrade using the dictionary
        ApplyUpgrade(Card, false);
        IsSell = false;

        StartCoroutine(UpdateInventory());
    }

    private void ApplyUpgrade(Upgrades upgrade, bool enable)
    {
        if (upgradeActions.ContainsKey(upgrade))
        {
            upgradeActions[upgrade](enable);
        }
    }

    public IEnumerator UpdateInventory()
    {
        yield return new WaitForSeconds(0.25f);
        inventory.UpdateCards();
        Destroy(gameObject);
    }
}