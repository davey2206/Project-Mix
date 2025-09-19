using UnityEngine;

public class Ball_Score_Multi : MonoBehaviour
{
    [SerializeField] Upgrade_Object Upgrades;
    [SerializeField] Score_Object Score;

    [Header("Stats")]
    [SerializeField] float MediumIsPremiumScore = 10;
    [SerializeField] float MediumIsPremiumMulti = 0.1f;
    [SerializeField] float BackToStartScore = 5;
    [SerializeField] float BackToStartMulti = 0.1f;
    [SerializeField] float DevilScore = -5;
    [SerializeField] float DevilScoreGood = 10;
    [SerializeField] float DevilMulti = -0.05f;
    [SerializeField] float DevilMultiGood = 0.1f;

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
    }
}
