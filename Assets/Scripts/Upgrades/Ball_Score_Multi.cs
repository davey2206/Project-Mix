using UnityEngine;

public class Ball_Score_Multi : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Score_Object Score;
    [SerializeField] Coin_Object Coins;

    [Header("Stats")]
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

    public void Enter(Ball ball)
    {
        Handle(ball.GetSize());
    }

    private void Handle(BallSize size)
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
        Debug.Log(size);
        if (size == BallSize.Gold && Upgrades.BigMergeSpawnGold)
        {
            Debug.Log("test");
            Score.AddMulti(BigMergeSpawnGold);
        }
    }
}
