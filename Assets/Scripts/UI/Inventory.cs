using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Transform Pool;
    [SerializeField] List<Upgrade_Card> Cards;
    [SerializeField] Upgrade_Object AllUpgrades;

    private void Awake()
    {
        GetCards();
    }

    private void OnEnable()
    {
        UpdateCards();
    }

    public void GetCards()
    {
        foreach (Transform child in Pool)
        {
            Cards.Add(child.GetComponent<Upgrade_Card>());
        }
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
                card.IsDisplay = true;
                Instantiate(card, transform);
            }
        }
    }
}
