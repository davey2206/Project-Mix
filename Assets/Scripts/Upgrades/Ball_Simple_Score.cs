using System.Collections.Generic;
using UnityEngine;

public class Ball_Simple_Score : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Score_Object Score;
    [Header("Score Stats")]
    [SerializeField] double TinyScore = 10;
    [SerializeField] double SmallScore = 10;
    [SerializeField] double MediumScore = 25;
    [SerializeField] double LargeScore = 25;
    [SerializeField] double HugeScore = 50;
    [SerializeField] double MegaScore = 50;
    [SerializeField] double GoldScore = 25;
    [SerializeField] double ResizeScore = 25;

    private Dictionary<BallSize, (System.Func<bool> upgradeCheck, double Score)> ballData;

    private void Awake()
    {
        ballData = new Dictionary<BallSize, (System.Func<bool>, double)>
        {
            { BallSize.tiny,    (() => Upgrades.TinyBallScore, TinyScore) },
            { BallSize.Small,   (() => Upgrades.SmallBallScore, SmallScore) },
            { BallSize.Medium,  (() => Upgrades.MediumBallScore, MediumScore) },
            { BallSize.Large,   (() => Upgrades.LargeBallScore, LargeScore) },
            { BallSize.Huge,    (() => Upgrades.HugeBallScore, HugeScore) },
            { BallSize.Mega,    (() => Upgrades.MegaBallScore, MegaScore) },
            { BallSize.Gold,    (() => Upgrades.GoldBallScore, GoldScore) },
            { BallSize.Resize,  (() => Upgrades.ResizeBallScore, ResizeScore) }
        };
    }

    public void SimpleScoreEnter(Ball ball)
    {
        HandleScore(ball.GetSize());
    }

    private void HandleScore(BallSize size)
    {
        if (ballData.TryGetValue(size, out var data))
        {
            if (data.upgradeCheck.Invoke())
            {
                Score.AddScore(data.Score);
            }
        }
    }
}
