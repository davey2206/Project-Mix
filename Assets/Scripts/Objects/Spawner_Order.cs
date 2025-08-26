using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawner Order", menuName = "ScriptableObjects/Spawner_Order", order = 1)]
public class Spawner_Order : ScriptableObject
{
    [SerializeField] public List<Ball> Balls;
    [SerializeField] public Ball CurrentBall;
    [SerializeField] public Ball NextBall;


    bool IsBomb = false;
    bool IsResize = false;
    bool IsGold = false;

    public void RollNextBall()
    {
        CurrentBall = NextBall;

        NextBall = Balls[Random.Range(0, Balls.Count)];
    }

    public void ResetToCurrent()
    {
        IsBomb = false;
        IsResize = false;
        IsGold = false;
    }

    public void SetBomb()
    {
        IsBomb = true;
    }

    public void SetResize()
    {
        IsResize = true;
    }

    public void SetGold()
    {
        IsGold = true;
    }

    public bool GetBomb()
    {
        return IsBomb;
    }

    public bool GetResize()
    {
        return IsResize;
    }

    public bool GetGold()
    {
        return IsGold;
    }
}
