using System.Collections.Generic;
using UnityEngine;

public class Shop_Inventory : MonoBehaviour
{
    [SerializeField] List<Upgrade_Card> Cards;
    [SerializeField] Upgrade_Object AllUpgrades;

    private void OnEnable()
    {
        UpdateCards();
    }

    public void UpdateCards()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var card in Cards)
        {
            if (AllUpgrades.CheckUpgrade(card.Card))
            {
                card.IsSell = true;
                Instantiate(card, transform);
            }
        }
    }
}
