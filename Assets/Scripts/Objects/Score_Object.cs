using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "ScriptableObjects/Score_Object", order = 1)]
public class Score_Object : ScriptableObject
{
    [SerializeField] double Score;
    [SerializeField] double Multi = 1;
    [SerializeField] double TotalScore;
    [SerializeField] bool CanScore = true;

    public void AddScore(double score)
    {
        if (CanScore)
        {
            Score += score;
            Score = Math.Round(Score, 2);
        }
    }

    public void RemoveScore(double score)
    {
        if (CanScore)
        {
            Score -= score;
            Score = Math.Round(Score, 2);
        }
    }

    public void AddMulti(double multi)
    {
        if (CanScore)
        {
            Multi += multi;
            Multi = Math.Round(Multi, 2);
        }
    }

    public void RemoveMulti(double multi)
    {
        if (CanScore)
        {
            Multi -= multi;
            Multi = Math.Round(Multi, 2);
        }
    }

    public void ResetScore()
    {
        CanScore = true;
        Score = 0;
        Multi = 1;
        TotalScore = 0;
    }

    public double GetTotalScore()
    {
        TotalScore = Score * Multi;
        return TotalScore;
    }

    public double GetScore() { return Score; }
    public double GetMulti() { return Multi; }

    public void DisableScore()
    {
        Debug.Log("test");
        CanScore = false;
    }
}
