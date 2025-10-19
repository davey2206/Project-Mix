using System.Drawing;
using UnityEngine;

public class Ball_Score_Multi : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Perks_Object Perks;
    [SerializeField] Score_Object Score;
    [SerializeField] Coin_Object Coins;

    [Header("Upgrade stats")]
    [SerializeField] float MediumIsPremiumScore = 10;
    [SerializeField] float MediumIsPremiumMulti = 0.1f;
    [SerializeField] float BackToStartScore = 5;
    [SerializeField] float BackToStartMulti = 0.1f;
    [SerializeField] float DevilScore = -5;
    [SerializeField] float DevilScoreGood = 10;
    [SerializeField] float DevilMulti = -0.05f;
    [SerializeField] float DevilMultiGood = 0.1f;
    [SerializeField] float GoldenEchoScore = 10;
    [SerializeField] float GoldenEchoMulti = 0.25f;
    [SerializeField] float BigMergeSpawnTiny = 0.25f;
    [SerializeField] float SmallMergeSpawnTiny = 10;
    [SerializeField] float BigMergeSpawnGold = 0.25f;
    [SerializeField] float SmallMergeSpawnGold = 10;
    [SerializeField] float MediumBonus = 50;
    [SerializeField] float TinyBonusScore = 25;
    [SerializeField] float TinyBonusMulti = 0.25f;
    [SerializeField] float ScoreCard = 5;
    [SerializeField] float TinyierTinyScore = 10;
    [SerializeField] float TinyierTinyMulti = 0.1f;

    [Header("Perks stats")]
    [SerializeField] float TinyMutli = 0.1f;
    [SerializeField] float TinyScore = 10f;
    [SerializeField] float SmallMutli = 0.1f;
    [SerializeField] float SmallScore = 10f;
    [SerializeField] float MediumMutli = 0.25f;
    [SerializeField] float MediumScore = 25f;
    [SerializeField] float GoldMutli = 0.25f;
    [SerializeField] float GoldScore = 50f;

    public void Enter(Ball ball)
    {
        PerkEffects(ball.GetSize());
        UpgradeEffects(ball.GetSize());
    }


    private void UpgradeEffects(BallSize size)
    {
        if (size == BallSize.Medium && Upgrades.MediumIsPremium)
        {
            Score.AddScore(MediumIsPremiumScore);
            Score.AddMulti(MediumIsPremiumMulti);
        }
        if (size == BallSize.tiny && Upgrades.BackToStart)
        {
            Score.AddScore(BackToStartScore);
            Score.AddMulti(BackToStartMulti);
        }
        if (Upgrades.DevilScore)
        {
            if (Upgrades.DevilMulti && Upgrades.DevilSize)
            {
                Score.AddScore(DevilScoreGood);
            }
            else
            {
                Score.AddScore(DevilScore);
            }
        }
        if (Upgrades.DevilMulti)
        {
            if (Upgrades.DevilScore && Upgrades.DevilSize)
            {
                Score.AddMulti(DevilMultiGood);
            }
            else
            {
                Score.AddMulti(DevilMulti);
            }
        }
        if (Upgrades.GoldenBonus)
        {
            float scoreToAdd = Coins.GetCoin() / 2;
            Score.AddScore(scoreToAdd);
        }
        if (size == BallSize.Gold && Upgrades.GoldenEcho)
        {
            Score.AddScore(GoldenEchoScore);
            Score.AddMulti(GoldenEchoMulti);
        }
        if (size == BallSize.tiny && Upgrades.SmallMergeSpawnTiny)
        {
            Score.AddScore(SmallMergeSpawnTiny);
        }
        if (size == BallSize.tiny && Upgrades.BigMergeSpawnTiny)
        {
            Score.AddMulti(BigMergeSpawnTiny);
        }
        if (size == BallSize.Gold && Upgrades.SmallMergeSpawnGold)
        {
            Score.AddScore(SmallMergeSpawnGold);
        }
        if (size == BallSize.Gold && Upgrades.BigMergeSpawnGold)
        {
            Score.AddMulti(BigMergeSpawnGold);
        }
        if (size == BallSize.Medium && Upgrades.MediumBonus)
        {
            Score.AddScore(MediumBonus);
        }
        if(size == BallSize.tiny && Upgrades.TinyBonus)
        {
            Score.AddScore(TinyBonusScore);
            Score.AddMulti(TinyBonusMulti);
        }
        if (Upgrades.ScoreCard)
        {
            Score.AddScore(ScoreCard * Upgrades.NumberOfUpgrades);
        }
        if (Upgrades.TinyierTiny)
        {
            Score.AddScore(TinyierTinyScore);
            Score.AddMulti(TinyierTinyMulti);
        }
    }

    private void PerkEffects(BallSize size)
    {
        if (size == BallSize.Small && Perks.SmallMulti)
        {
            Score.AddMulti(SmallMutli);
        }
        if (size == BallSize.Small && Perks.SmallScore)
        {
            Score.AddScore(SmallScore);
        }
        if (size == BallSize.tiny && Perks.TinyMulti)
        {
            Score.AddMulti(TinyMutli);
        }
        if (size == BallSize.tiny && Perks.TinyScore)
        {
            Score.AddScore(TinyScore);
        }
        if (size == BallSize.Gold && Perks.GoldMulti)
        {
            Score.AddMulti(GoldMutli);
        }
        if (size == BallSize.Gold && Perks.GoldScore)
        {
            Score.AddScore(GoldScore);
        }
        if (size == BallSize.Medium && Perks.MediumMulti)
        {
            Score.AddMulti(MediumMutli);
        }
        if (size == BallSize.Medium && Perks.MediumScore)
        {
            Score.AddScore(MediumScore);
        }
    }
}
