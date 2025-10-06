using System.Collections.Generic;
using UnityEngine;

public class Final_Spark : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] List<Transform> Spawns;
    [SerializeField] GameObject Bomb;
    private bool isInside = false;
    private bool Used = false;
    private float timer = 0f;

    private void OnEnable()
    {
        Used = false;
    }

    private void Update()
    {
        if (Upgrades.FinalSpark && isInside && !Used)
        {
            timer += Time.deltaTime;

            if (timer >= 3f)
            {
                Used = true;
                foreach (Transform Spawn in Spawns) 
                {
                    Instantiate(Bomb, Spawn.position, Quaternion.identity);
                }
                timer = 0f;
                isInside = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInside = true;
        timer = 0f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
        timer = 0f;
    }
}
