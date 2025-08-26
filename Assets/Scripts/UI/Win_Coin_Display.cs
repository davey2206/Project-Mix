using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Coin_Display : MonoBehaviour
{
    [SerializeField] Level_Manager Level;
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
        for (int i = 0; i < Level.GetLevel().Coins; i++)
        {
            yield return new WaitForSeconds(0.2f);
            Instantiate(Coin, transform);
        }
    }
}
