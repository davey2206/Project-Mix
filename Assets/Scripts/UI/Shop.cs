using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] Transform Pool;
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] List<Upgrade_Card> Cards;

    private void OnEnable()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        GetCards();
        SpawnCards();
    }

    public void GetCards()
    {
        Cards.Clear();

        foreach (Transform child in Pool)
        {
            Cards.Add(child.GetComponent<Upgrade_Card>());
        }
    }

    public void SpawnCards()
    {
        List<Upgrade_Card> CardList = new List<Upgrade_Card>(Cards);

        for (int i = CardList.Count - 1; i >= 0; i--)
        {
            var card = CardList[i];
            if (Upgrades.CheckUpgrade(card.Card))
            {
                card.IsSell = true;
                CardList.RemoveAt(i);
            }
        }

        int count = CardList.Count;

        if (count > 3)
        {
            count = 3;
        }

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, CardList.Count);
            Upgrade_Card card = CardList[randomIndex];

            Instantiate(card, transform);

            CardList.RemoveAt(randomIndex);
        }
    }
}
