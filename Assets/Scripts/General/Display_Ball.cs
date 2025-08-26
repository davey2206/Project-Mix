using System.Collections.Generic;
using UnityEngine;

public class Display_Ball : MonoBehaviour
{
    [SerializeField] Spawner_Order Order;
    [SerializeField] List<GameObject> DisplayBall;
    [SerializeField] bool IsNext;

    private void Update()
    {
        if (IsNext)
        {
            var ball = (Order.GetBomb() || Order.GetResize() || Order.GetGold()) ? Order.CurrentBall : Order.NextBall;
            ShowOnly((int)ball.GetSize());
        }
        else
        {
            ShowOnly((int)Order.CurrentBall.GetSize());
            DisplayBall[6].SetActive(false);

            if (Order.GetBomb())
            {
                ShowOnly(6);
            }
            else if (Order.GetResize())
            {
                ShowOnly(7);
            }
            else if (Order.GetGold())
            {
                ShowOnly(8);
            }
        }
    }

    private void ShowOnly(int index)
    {
        for (int i = 0; i < DisplayBall.Count; i++)
        {
            DisplayBall[i].SetActive(i == index);
        }
    }
}
