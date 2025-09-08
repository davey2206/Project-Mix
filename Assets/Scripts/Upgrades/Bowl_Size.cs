using System.Collections.Generic;
using UnityEngine;

public class Bowl_Size : MonoBehaviour
{
    [SerializeField] List<GameObject> Bolls;
    [SerializeField] Upgrade_Object Upgrades;

    // Update is called once per frame
    void Update()
    {
        switch (Upgrades.BowlSize)
        {
            case 1:
                Bolls[0].SetActive(true);
                Bolls[1].SetActive(false);
                Bolls[2].SetActive(false);
                Bolls[3].SetActive(false);
                break;
            case 2:
                Bolls[0].SetActive(false);
                Bolls[1].SetActive(true);
                Bolls[2].SetActive(false);
                Bolls[3].SetActive(false);
                break;
            case 3:
                Bolls[0].SetActive(false);
                Bolls[1].SetActive(false);
                Bolls[2].SetActive(true);
                Bolls[3].SetActive(false);
                break;
            case 4:
                Bolls[0].SetActive(false);
                Bolls[1].SetActive(false);
                Bolls[2].SetActive(false);
                Bolls[3].SetActive(true);
                break;
            default:
                Bolls[0].SetActive(true);
                Bolls[1].SetActive(false);
                Bolls[2].SetActive(false);
                Bolls[3].SetActive(false);
                break;

        }
    }
}
