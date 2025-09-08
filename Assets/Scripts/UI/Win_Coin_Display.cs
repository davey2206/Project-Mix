using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Coin_Display : MonoBehaviour
{
    [SerializeField] Level_Manager Level;
    [SerializeField] Coin_Object LevelCoin;
    [SerializeField] GameObject Coin;

    private void OnEnable()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        StartCoroutine(Coins());
    }

    IEnumerator Coins()
    {
        float coins = Level.GetLevel().Coins + LevelCoin.LevelCoin;
        for (int i = 0; i < coins; i++)
        {
            yield return new WaitForSeconds(0.2f);
            Instantiate(Coin, transform);
        }
        LevelCoin.LevelCoin = 0;
    }
}
