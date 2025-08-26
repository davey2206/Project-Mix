using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Ball_Simple_Multi : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Score_Object Score;
    [Header("Multi Stats")]
    [SerializeField] double TinyMulti = 0.1;
    [SerializeField] double SmallMulti = 0.1;
    [SerializeField] double MediumMulti = 0.25;
    [SerializeField] double LargeMulti = 0.25;
    [SerializeField] double HugeMulti = 0.5;
    [SerializeField] double MegaMulti = 0.5;
    [SerializeField] double GoldMulti = 0.5;
    [SerializeField] double ResizeMulti = 0.5;
    [SerializeField] double MultiMulti = 2;

    private Dictionary<BallSize, (System.Func<bool> upgradeCheck, double multiplier)> ballData;

    private void Awake()
    {
        ballData = new Dictionary<BallSize, (System.Func<bool>, double)>
        {
            { BallSize.tiny,    (() => Upgrades.TinyBallMulti, TinyMulti) },
            { BallSize.Small,   (() => Upgrades.SmallBallMulti, SmallMulti) },
            { BallSize.Medium,  (() => Upgrades.MediumBallMulti, MediumMulti) },
            { BallSize.Large,   (() => Upgrades.LargeBallMulti, LargeMulti) },
            { BallSize.Huge,    (() => Upgrades.HugeBallMulti, HugeMulti) },
            { BallSize.Mega,    (() => Upgrades.MegaBallMulti, MegaMulti) },
            { BallSize.Gold,    (() => Upgrades.GoldBallMulti, GoldMulti) },
            { BallSize.Resize,  (() => Upgrades.ResizeBallMulti, ResizeMulti) },
            { BallSize.Multi,   (() => true, MultiMulti) } // Always applies
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            BallSize size = collision.GetComponent<Ball>().GetSize();
            HandleMultiplier(size, add: true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            BallSize size = collision.GetComponent<Ball>().GetSize();
            HandleMultiplier(size, add: false);
        }
    }

    private void HandleMultiplier(BallSize size, bool add)
    {
        if (ballData.TryGetValue(size, out var data))
        {
            if (add)
            {
                if (data.upgradeCheck.Invoke())
                {
                    Score.AddMulti(data.multiplier);
                }
            }
        }
    }
}
