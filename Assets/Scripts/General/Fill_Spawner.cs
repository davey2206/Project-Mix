using System.Collections.Generic;
using UnityEngine;

public class Fill_Spawner : MonoBehaviour
{
    [SerializeField] Spawner_Order SpawnerOrder;


    [SerializeField] public List<Ball> Balls;
    [SerializeField] public Ball CurrentBall;
    [SerializeField] public Ball NextBall;

    private void OnEnable()
    {
        SpawnerOrder.Balls = Balls;
        SpawnerOrder.CurrentBall = CurrentBall;
        SpawnerOrder.NextBall = NextBall;
    }
}
